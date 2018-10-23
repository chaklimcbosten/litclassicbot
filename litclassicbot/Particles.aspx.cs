using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using litclassicbot.Classes;


namespace litclassicbot
{
    public partial class Particles : System.Web.UI.Page
    {
        private int currentParticleId = -1;
        //private Dictionary<string, int> particleSettingsDictionary = new Dictionary<string, int>();
        private int currentRandomThemeType = -1;
        private int currentRandomAuthorNumber = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Cookie записывается верно при первом открытии страницы (когда cookie-файл не создан)
            // 2. Cookie записывается верно при смене значения checkbox, когда, опять же, cookie-файл ещё не создан
            // 3. Cookie сохраняется при обновлении страницы один раз после ситуации в п.2, далее обнуляется
            // 4. Cookie обнуляется при обновлении страницы после п.1.

            // если у пользователя разрешены cookie - использовать их
            // сверять затем их с базой, привязать к логину (пока без пароля)
            // если не разрешены - использовать сеансы без использования cookie

            // стихотворные "частицы" разделять на несколько блоков и с помощью свойств flex
            // распологать в несколько столбцов


            // регистрация асинхронных запросов в ScriptManager
            ScriptManagerSetting();
            // настройка персонализации страницы, если она открывается впервые
            PageSetting();
        }

        
        private void ScriptManagerSetting()
        {
            // UpdatePanelParticlesPage
            ScriptManagerParticlesPage.RegisterAsyncPostBackControl(ButtonParticleReload);
        }
        private void PageSetting()
        {
            if (!IsPostBack)
            {
                // если браузер поддерживает cookie
                if (Request.Browser.Cookies)
                {
                    Response.Cookies["litclassic-cookie-user-info"]["last-visit"] = DateTime.Now.ToString();
                    Response.Cookies["litclassic-cookie-user-info"].Expires = DateTime.Now.AddYears(3);

                    // первое посещение, если cookie не созданы
                    if (Request.Cookies["litclassic-cookie-particle"] == null)
                    {
                        Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "0";
                        Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "0";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-0"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-1"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-2"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-3"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-4"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-5"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-6"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-7"] = "1";
                        Response.Cookies["litclassic-cookie-particle"]["author-number-8"] = "1";
                        Response.Cookies["litclassic-cookie-particle"].Expires = DateTime.Now.AddYears(3);

                        SetNewRandomIDParticle();
                        ShowParticle(currentParticleId);
                    }
                    // cookie-файл существует
                    else
                    {
                        // изменяются настройки
                        CheckParticleSettingsCookie();

                        // если cookie-файла с ID "частицы" нет, или этот ID обнулён
                        if ((Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["particleID"]) == null))
                        {
                            SetNewRandomIDParticle();
                            ShowParticle(currentParticleId);

                            Response.Cookies["litclassic-cookie-particle"]["particleID"] 
                                = Convert.ToString(currentParticleId);
                        }
                        // если ID "частицы" задан
                        else
                        {
                            ShowParticle(Convert.ToInt32(Server.HtmlEncode(
                                Request.Cookies["litclassic-cookie-particle"]["particleID"])));
                        }
                    }
                }
                // если браузер не поддерживает cookie
                else
                {
                    // если у текущей сесси нет данных
                    if (Session["particleID"] == null)
                    {
                        Session["theme-type-0"] = true;
                        Session["theme-type-1"] = false;
                        Session["theme-type-2"] = false;
                        Session["author-number-0"] = true;
                        Session["author-number-1"] = true;
                        Session["author-number-2"] = true;
                        Session["author-number-3"] = true;
                        Session["author-number-4"] = true;
                        Session["author-number-5"] = true;
                        Session["author-number-6"] = true;
                        Session["author-number-7"] = true;
                        Session["author-number-8"] = true;
                    }
                    // если у текущей сессии уже есть данные
                    else CheckParticleSettingsSession();

                    SetNewRandomIDParticle();
                    ShowParticle(currentParticleId);
                }
            }           
        }
        private void CheckParticleSettingsCookie()
        {
            // theme-type-0
            if (Request.Cookies["litclassic-cookie-particle"]["theme-type-0"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-0"]) == "1")
                    CheckBoxThemeType0.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-0"]) == "0")
                    CheckBoxThemeType0.Checked = false;
            }
            else
            {
                CheckBoxThemeType0.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "1";
            }
            // theme-type-1
            if (Request.Cookies["litclassic-cookie-particle"]["theme-type-1"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-1"]) == "1")
                    CheckBoxThemeType1.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-1"]) == "0")
                    CheckBoxThemeType1.Checked = false;
            }
            else
            {
                CheckBoxThemeType1.Checked = false;
                Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "0";
            }
            // theme-type-2
            if (Request.Cookies["litclassic-cookie-particle"]["theme-type-2"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-2"]) == "1")
                    CheckBoxThemeType2.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-2"]) == "0")
                    CheckBoxThemeType2.Checked = false;
            }
            else
            {
                CheckBoxThemeType2.Checked = false;
                Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "0";
            }

            // author-number-0
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-0"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-0"]) == "1")
                    CheckBoxAuthor0.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-0"]) == "0")
                    CheckBoxAuthor0.Checked = false;
            }
            else
            {
                CheckBoxAuthor0.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-0"] = "1";
            }
            // author-number-1
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-1"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-1"]) == "1")
                    CheckBoxAuthor1.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-1"]) == "0")
                    CheckBoxAuthor1.Checked = false;
            }
            else
            {
                CheckBoxAuthor1.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-1"] = "1";
            }
            // author-number-2
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-2"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-2"]) == "1")
                    CheckBoxAuthor2.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-2"]) == "0")
                    CheckBoxAuthor2.Checked = false;
            }
            else
            {
                CheckBoxAuthor2.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-2"] = "1";
            }
            // author-number-3
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-3"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-3"]) == "1")
                    CheckBoxAuthor3.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-3"]) == "0")
                    CheckBoxAuthor3.Checked = false;
            }
            else
            {
                CheckBoxAuthor3.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-3"] = "1";
            }
            // author-number-4
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-4"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-4"]) == "1")
                    CheckBoxAuthor4.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-4"]) == "0")
                    CheckBoxAuthor4.Checked = false;
            }
            else
            {
                CheckBoxAuthor4.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-4"] = "1";
            }
            // author-number-5
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-5"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-5"]) == "1")
                    CheckBoxAuthor5.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-5"]) == "0")
                    CheckBoxAuthor5.Checked = false;
            }
            else
            {
                CheckBoxAuthor5.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-5"] = "1";
            }
            // author-number-6
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-6"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-6"]) == "1")
                    CheckBoxAuthor6.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-6"]) == "0")
                    CheckBoxAuthor6.Checked = false;
            }
            else
            {
                CheckBoxAuthor6.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-6"] = "1";
            }
            // author-number-7
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-7"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-7"]) == "1")
                    CheckBoxAuthor7.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-7"]) == "0")
                    CheckBoxAuthor7.Checked = false;
            }
            else
            {
                CheckBoxAuthor7.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-7"] = "1";
            }
            // author-number-8
            if (Request.Cookies["litclassic-cookie-particle"]["author-number-8"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-8"]) == "1")
                    CheckBoxAuthor8.Checked = true;
                else if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-8"]) == "0")
                    CheckBoxAuthor8.Checked = false;
            }
            else
            {
                CheckBoxAuthor8.Checked = true;
                Response.Cookies["litclassic-cookie-particle"]["author-number-8"] = "1";
            }
        }
        private void SetParticleSettingsCookie()
        {
            // theme-type-0
            if (CheckBoxThemeType0.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "1";
            else if (!CheckBoxThemeType0.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "0";
            // theme-type-1
            if (CheckBoxThemeType1.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "1";
            else if (!CheckBoxThemeType1.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "0";
            // theme-type-2
            if (CheckBoxThemeType2.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "1";
            else if (!CheckBoxThemeType2.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "0";

            // author-number-0
            if (CheckBoxAuthor0.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-0"] = "1";
            else if (!CheckBoxAuthor0.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-0"] = "0";
            // author-number-1
            if (CheckBoxAuthor1.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-1"] = "1";
            else if (!CheckBoxAuthor1.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-1"] = "0";
            // author-number-2
            if (CheckBoxAuthor2.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-2"] = "1";
            else if (!CheckBoxAuthor2.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-2"] = "0";
            // author-number-3
            if (CheckBoxAuthor3.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-3"] = "1";
            else if (!CheckBoxAuthor3.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-3"] = "0";
            // author-number-4
            if (CheckBoxAuthor4.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-4"] = "1";
            else if (!CheckBoxAuthor4.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-4"] = "0";
            // author-number-5
            if (CheckBoxAuthor5.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-5"] = "1";
            else if (!CheckBoxAuthor5.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-5"] = "0";
            // author-number-6
            if (CheckBoxAuthor6.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-6"] = "1";
            else if (!CheckBoxAuthor6.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-6"] = "0";
            // author-number-7
            if (CheckBoxAuthor7.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-7"] = "1";
            else if (!CheckBoxAuthor7.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-7"] = "0";
            // author-number-8
            if (CheckBoxAuthor8.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-8"] = "1";
            else if (!CheckBoxAuthor8.Checked) Response.Cookies["litclassic-cookie-particle"]["author-number-8"] = "0";

            Response.Cookies["litclassic-cookie-particle"].Expires = DateTime.Now.AddYears(3);
            Response.Cookies["litclassic-cookie-user-info"]["last-visit"] = DateTime.Now.ToString();
            Response.Cookies["litclassic-cookie-user-info"].Expires = DateTime.Now.AddYears(3);
        }
        private void CheckParticleSettingsSession()
        {
            // theme-type-0
            if ((bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = true;
            else if (!(bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = false;
            // theme-type-1
            if ((bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = true;
            else if (!(bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = false;
            // theme-type-2
            if ((bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = true;
            else if (!(bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = false;

            // author-number-0
            if ((bool)Session["author-number-0"]) CheckBoxAuthor0.Checked = true;
            else if (!(bool)Session["author-number-0"]) CheckBoxAuthor0.Checked = false;
            // author-number-1
            if ((bool)Session["author-number-1"]) CheckBoxAuthor1.Checked = true;
            else if (!(bool)Session["author-number-1"]) CheckBoxAuthor1.Checked = false;
            // author-number-2
            if ((bool)Session["author-number-2"]) CheckBoxAuthor2.Checked = true;
            else if (!(bool)Session["author-number-2"]) CheckBoxAuthor2.Checked = false;
            // author-number-3
            if ((bool)Session["author-number-3"]) CheckBoxAuthor3.Checked = true;
            else if (!(bool)Session["author-number-3"]) CheckBoxAuthor3.Checked = false;
            // author-number-4
            if ((bool)Session["author-number-4"]) CheckBoxAuthor4.Checked = true;
            else if (!(bool)Session["author-number-4"]) CheckBoxAuthor4.Checked = false;
            // author-number-5
            if ((bool)Session["author-number-5"]) CheckBoxAuthor5.Checked = true;
            else if (!(bool)Session["author-number-5"]) CheckBoxAuthor5.Checked = false;
            // author-number-6
            if ((bool)Session["author-number-6"]) CheckBoxAuthor6.Checked = true;
            else if (!(bool)Session["author-number-6"]) CheckBoxAuthor6.Checked = false;
            // author-number-7
            if ((bool)Session["author-number-7"]) CheckBoxAuthor7.Checked = true;
            else if (!(bool)Session["author-number-7"]) CheckBoxAuthor7.Checked = false;
            // author-number-8
            if ((bool)Session["author-number-8"]) CheckBoxAuthor8.Checked = true;
            else if (!(bool)Session["author-number-8"]) CheckBoxAuthor8.Checked = false;
        }
        private void SetParticleSettingsSession()
        {
            // theme-type-0
            if (CheckBoxThemeType0.Checked) Session["theme-type-0"] = true;
            else Session["theme-type-0"] = false;
            // theme-type-1
            if (CheckBoxThemeType1.Checked) Session["theme-type-1"] = true;
            else Session["theme-type-1"] = false;
            // theme-type-2
            if (CheckBoxThemeType2.Checked) Session["theme-type-2"] = true;
            else Session["theme-type-2"] = false;

            // author-number-0
            if (CheckBoxAuthor0.Checked) Session["author-number-0"] = true;
            else Session["author-number-0"] = false;
            // author-number-1
            if (CheckBoxAuthor1.Checked) Session["author-number-1"] = true;
            else Session["author-number-1"] = false;
            // author-number-2
            if (CheckBoxAuthor2.Checked) Session["author-number-2"] = true;
            else Session["author-number-2"] = false;
            // author-number-3
            if (CheckBoxAuthor3.Checked) Session["author-number-3"] = true;
            else Session["author-number-3"] = false;
            // author-number-4
            if (CheckBoxAuthor4.Checked) Session["author-number-4"] = true;
            else Session["author-number-4"] = false;
            // author-number-5
            if (CheckBoxAuthor5.Checked) Session["author-number-5"] = true;
            else Session["author-number-5"] = false;
            // author-number-6
            if (CheckBoxAuthor6.Checked) Session["author-number-6"] = true;
            else Session["author-number-6"] = false;
            // author-number-7
            if (CheckBoxAuthor7.Checked) Session["author-number-7"] = true;
            else Session["author-number-7"] = false;
            // author-number-8
            if (CheckBoxAuthor8.Checked) Session["author-number-8"] = true;
            else Session["author-number-8"] = false;
        }
        private void ShowParticle(int particleID)
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            Dictionary<string, object> particleQueryDictionary = new Dictionary<string, object>();
            particleQueryDictionary = currentConnection.GetParticle(Session.SessionID, "web", particleID);
            string particle = (string)particleQueryDictionary["line"];
            string title = (string)particleQueryDictionary["title"]; ;
            int indeLastLine = (int)particleQueryDictionary["indexLastLine"]; ;
            currentParticleId = (int)particleQueryDictionary["particleId"]; ;
            int bookId = (int)particleQueryDictionary["bookId"]; ;
            // создаёт "обёрточный" класс для всего содержания "частицы"
            string beginParticle = "<div class=\"black-label-main-content\"><p>";
            string endParticle = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            particle = beginParticle + particle.Replace("\n\r", "</p><p>") + endParticle;
            particle = particle.Replace("$$strong-open$$", "<strong>");
            particle = particle.Replace("$$emphasis-open$$", "<emphasis>");
            particle = particle.Replace("$$strong-close$$", "</strong>");
            particle = particle.Replace("$$emphasis-close$$", "</emphasis>");
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"black-label-main-content\"><p>";
            string endTitle = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelParticleLine.Text = particle;
            //randomParticalButtonText = partical;
            LabelParticleTitle.Text = title;
        }
        private void ShowRandomParticle()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<string> listGetRandomParticle = new List<string>();
            listGetRandomParticle = currentConnection.GetRandomParticle("web");
            string particle = listGetRandomParticle[0];
            string title = listGetRandomParticle[1];
            int indeLastLine = Convert.ToInt32(listGetRandomParticle[2]);
            // для отправки сообщения об ошибке
            currentParticleId = Convert.ToInt32(listGetRandomParticle[3]);
            int bookID = Convert.ToInt32(listGetRandomParticle[4]);
            // создаёт "обёрточный" класс для всего содержания "частицы"
            string beginParticle = "<div class=\"label-particle-line\"><p>";
            string endParticle = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            particle = beginParticle + particle.Replace("\n\r", "</p><p>") + endParticle;
            particle = particle.Replace("$$strong-open$$", "<strong>");
            particle = particle.Replace("$$emphasis-open$$", "<emphasis>");
            particle = particle.Replace("$$strong-close$$", "</strong>");
            particle = particle.Replace("$$emphasis-close$$", "</emphasis>");
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"label-particle-title\">";
            string endTitle = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelParticleLine.Text = particle;
            //randomParticalButtonText = partical;
            LabelParticleTitle.Text = title;
        }
        private void SetNewRandomIDParticle()
        {
            // должен узнать, из каких цифр нужно будет выбирать случайные
            // построить диапазон
            // найти случайное
            // найти, какое из выбранных соответствовало ему

            // присваивание значениям настроек получения "частиц" значений
            CheckThemeTypesAndAuthorsNumbers();

            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            // если значениям настроек присвоены значения
            if ((currentRandomThemeType == -1) && (currentRandomAuthorNumber == -1))
                currentParticleId = currentConnection.GetRandomParticleId();
            // если значениям настроек не присвоены значения
            else currentParticleId = currentConnection.GetRandomParticleId(currentRandomAuthorNumber, currentRandomThemeType);

            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) Response.Cookies["litclassic-cookie-particle"]["particleID"] 
                    = Convert.ToString(currentParticleId);
            // если браузер не поддерживает cookie
            else Session["particleID"] = currentParticleId;           
        }
        private void CheckThemeTypesAndAuthorsNumbers()
        {
            // если браузер поддерживает cookie
            if (Request.Browser.Cookies)
            {
                List<int> listThemeTypes = new List<int>();
                List<int> listAuthorsNumbers = new List<int>();

                for (int iCookieThemeType = 0; iCookieThemeType < 3; iCookieThemeType++)
                {
                    if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["theme-type-" + iCookieThemeType]) == "1")
                        listThemeTypes.Add(iCookieThemeType);
                }

                for (int iCookieAuthorNumber = 0; iCookieAuthorNumber < 9; iCookieAuthorNumber++)
                {
                    if (Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["author-number-" + iCookieAuthorNumber]) == "1")
                        listAuthorsNumbers.Add(iCookieAuthorNumber);
                }

                Random randomThemeType = new Random();
                Random randomAuthorNumber = new Random();
                currentRandomThemeType = listThemeTypes[randomThemeType.Next(0, listThemeTypes.Count() - 1)];
                currentRandomAuthorNumber = listAuthorsNumbers[randomAuthorNumber.Next(0, listAuthorsNumbers.Count() - 1)];                
            }
            // если браузер не поддерживает cookie
            else
            {
                List<int> listThemeTypes = new List<int>();
                List<int> listAuthorsNumbers = new List<int>();

                for (int iSessionThemeType = 0; iSessionThemeType < 3; iSessionThemeType++)
                {
                    if ((bool)Session["theme-type-" + iSessionThemeType] == true)
                        listThemeTypes.Add(iSessionThemeType);
                }

                for (int iSessionAuthorNumber = 0; iSessionAuthorNumber < 9; iSessionAuthorNumber++)
                {
                    if ((bool)Session["author-number-" + iSessionAuthorNumber] == true)
                        listAuthorsNumbers.Add(iSessionAuthorNumber);
                }

                Random randomThemeType = new Random();
                Random randomAuthorNumber = new Random();
                currentRandomThemeType = listThemeTypes[randomThemeType.Next(0, listThemeTypes.Count() - 1)];
                currentRandomAuthorNumber = listAuthorsNumbers[randomAuthorNumber.Next(0, listAuthorsNumbers.Count() - 1)];
            }
        }
        private void ReportParticle()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
            currentConnection.WriteNewParticleReportByParticleId(currentParticleId.ToString());
        }
        private void CheckCheckBoxes()
        {
            // нельзя оставлять все чекбоксы пустыми
            if ((CheckBoxThemeType0.Checked == false)
                && (CheckBoxThemeType1.Checked == false)
                && (CheckBoxThemeType2.Checked == false))
                CheckBoxThemeType0.Checked = true;
            if ((CheckBoxAuthor0.Checked == false)
                && (CheckBoxAuthor1.Checked == false)
                && (CheckBoxAuthor2.Checked == false)
                && (CheckBoxAuthor3.Checked == false)
                && (CheckBoxAuthor4.Checked == false)
                && (CheckBoxAuthor5.Checked == false)
                && (CheckBoxAuthor6.Checked == false)
                && (CheckBoxAuthor7.Checked == false)
                && (CheckBoxAuthor8.Checked == false))
                CheckBoxAuthor0.Checked = true;
        }

        

        protected void ButtonParticleReload_Click(object sender, EventArgs e)
        {
            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) SetParticleSettingsCookie();         
            // если браузер не поддерживает cookie
            else SetParticleSettingsSession();           

            SetNewRandomIDParticle();
            ShowParticle(currentParticleId);
            UpdatePanelParticle.Update();
        }
        protected void CheckBoxThemeType0_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void CheckBoxThemeType1_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void CheckBoxThemeType2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
