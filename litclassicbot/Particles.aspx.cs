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
        private int currentParticleID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Cookie записывается верно при первом открытии страницы (когда cookie-файл не создан)
            // 2. Cookie записывается верно при смене значения checkbox, когда, опять же, cookie-файл ещё не создан
            // 3. Cookie сохраняется при обновлении страницы один раз после ситуации в п.2, далее обнуляется
            // 4. Cookie обнуляется при обновлении страницы после п.1.

            // если у пользователя разрешены cookie - использовать их
            // сверять затем их с базой, привязать к логину (пока без пароля)
            // если не разрешены - использовать сеансы без использования cookie

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
                        Response.Cookies["litclassic-cookie-particle"].Expires = DateTime.Now.AddYears(3);

                        SetNewRandomIDParticle();
                        ShowParticle(currentParticleID);
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
                            ShowParticle(currentParticleID);

                            Response.Cookies["litclassic-cookie-particle"]["particleID"] 
                                = Convert.ToString(currentParticleID);
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
                    }
                    // если у текущей сессии уже есть данные
                    else CheckParticleSettingsSession();

                    SetNewRandomIDParticle();
                    ShowParticle(currentParticleID);
                }
            }           
        }
        private void CheckParticleSettingsCookie()
        {
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
        }
        private void SetParticleSettingsCookie()
        {
            if (CheckBoxThemeType0.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "1";
            else if (!CheckBoxThemeType0.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-0"] = "0";

            if (CheckBoxThemeType1.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "1";
            else if (!CheckBoxThemeType1.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-1"] = "0";

            if (CheckBoxThemeType2.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "1";
            else if (!CheckBoxThemeType2.Checked) Response.Cookies["litclassic-cookie-particle"]["theme-type-2"] = "0";

            Response.Cookies["litclassic-cookie-particle"].Expires = DateTime.Now.AddYears(3);
            Response.Cookies["litclassic-cookie-user-info"]["last-visit"] = DateTime.Now.ToString();
            Response.Cookies["litclassic-cookie-user-info"].Expires = DateTime.Now.AddYears(3);
        }
        private void CheckParticleSettingsSession()
        {
            if ((bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = true;
            else if (!(bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = false;

            if ((bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = true;
            else if (!(bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = false;

            if ((bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = true;
            else if (!(bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = false;
        }
        private void SetParticleSettingsSession()
        {
            if (CheckBoxThemeType0.Checked) Session["theme-type-0"] = true;
            else Session["theme-type-0"] = false;

            if (CheckBoxThemeType1.Checked) Session["theme-type-1"] = true;
            else Session["theme-type-1"] = false;

            if (CheckBoxThemeType2.Checked) Session["theme-type-2"] = true;
            else Session["theme-type-2"] = false;
        }
        private void ShowParticle(int particleID)
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<string> listGetParticle = new List<string>();
            listGetParticle = currentConnection.GetParticle("web", particleID);
            string particle = listGetParticle[0];
            string title = listGetParticle[1];
            int indeLastLine = Convert.ToInt32(listGetParticle[2]);
            // для отправки сообщения об ошибке
            currentParticleID = Convert.ToInt32(listGetParticle[3]);
            int bookID = Convert.ToInt32(listGetParticle[4]);
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
            currentParticleID = Convert.ToInt32(listGetRandomParticle[3]);
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
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            currentParticleID = currentConnection.GetRandomParticleID();

            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) Response.Cookies["litclassic-cookie-particle"]["particleID"] 
                    = Convert.ToString(currentParticleID);
            // если браузер не поддерживает cookie
            else Session["particleID"] = currentParticleID;           
        }
        private void ReportParticle()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
            currentConnection.WriteNewParticleReportByParticleID(currentParticleID.ToString());
        }
        private void CheckCheckBoxes()
        {
            // нельзя оставлять все чекбоксы пустыми
            if ((CheckBoxThemeType0.Checked == false)
                && (CheckBoxThemeType1.Checked == false)
                && (CheckBoxThemeType2.Checked == false))
                CheckBoxThemeType0.Checked = true;
        }

        

        protected void ButtonParticleReload_Click(object sender, EventArgs e)
        {
            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) SetParticleSettingsCookie();         
            // если браузер не поддерживает cookie
            else SetParticleSettingsSession();           

            SetNewRandomIDParticle();
            ShowParticle(currentParticleID);
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
