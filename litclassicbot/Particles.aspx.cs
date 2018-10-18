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
        // "частица" должна быть одна, должна открываться та же самая при каждом заходе на страницу "частиц"
        // смена "частицы" будет происходить только лишь при нажатии клавиши "обновить"

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

            if (Request.Browser.Cookies)
            {

            }
            else
            {

            }


            if (Session.IsNewSession)
            {
                ShowRandomParticle();

                Session["particleID"] = currentParticleID;
                Session["theme-type-0"] = true;
                Session["theme-type-1"] = false;
                Session["theme-type-2"] = false;
            }
            else
            {
                // сессия может быть уже создана, но particleID в ней может ещё не быть
                try
                {
                    // если "частице" не задан ID, надо получить новый ID
                    if ((int)Session["particleID"] == -1)
                    {
                        ShowRandomParticle();

                        Session["particleID"] = currentParticleID;

                        if ((bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = true;
                        else CheckBoxThemeType0.Checked = false;

                        if ((bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = true;
                        else CheckBoxThemeType1.Checked = false;

                        if ((bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = true;
                        else CheckBoxThemeType2.Checked = false;
                    }
                    // если "частице" задан ID
                    else
                    {
                        ShowParticle((int)Session["particleID"]);

                        if ((bool)Session["theme-type-0"]) CheckBoxThemeType0.Checked = true;
                        else CheckBoxThemeType0.Checked = false;

                        if ((bool)Session["theme-type-1"]) CheckBoxThemeType1.Checked = true;
                        else CheckBoxThemeType1.Checked = false;

                        if ((bool)Session["theme-type-2"]) CheckBoxThemeType2.Checked = true;
                        else CheckBoxThemeType2.Checked = false;
                    }
                }
                catch
                {
                    ShowRandomParticle();

                    Session["particleID"] = currentParticleID;
                    Session["theme-type-0"] = true;
                    Session["theme-type-1"] = false;
                    Session["theme-type-2"] = false;
                }
            }

            if (Request.Cookies["litclassic-cookie"] != null)
            {
                //if (Server.HtmlEncode(Request.Cookies["litclassic-cookie"]["theme-type-0"]) == "true")
                //    CheckBoxThemeType0.Checked = true;
                //else CheckBoxThemeType0.Checked = false;
                //if (Server.HtmlEncode(Request.Cookies["litclassic-cookie"]["theme-type-1"]) == "true")
                //    CheckBoxThemeType1.Checked = true;
                //else CheckBoxThemeType1.Checked = false;
                //if (Server.HtmlEncode(Request.Cookies["litclassic-cookie"]["theme-type-2"]) == "true")
                //    CheckBoxThemeType2.Checked = true;
                //else CheckBoxThemeType2.Checked = false;

                //Response.Cookies["litclassic-cookie"].Expires = DateTime.Now.AddYears(3);
            }
            else
            {
                //CheckBoxThemeType0.Checked = true;

                //Response.Cookies["litclassic-cookie"]["theme-type-0"] = "true";
                //Response.Cookies["litclassic-cookie"]["theme-type-1"] = "false";
                //Response.Cookies["litclassic-cookie"]["theme-type-2"] = "false";
                //Response.Cookies["litclassic-cookie"].Expires = DateTime.Now.AddYears(3);
            }

            Response.Cookies["litclassic-cookie-user-info"]["last-visit"] = DateTime.Now.ToString();          
            Response.Cookies["litclassic-cookie-user-info"].Expires = DateTime.Now.AddYears(3);
        }


        private void ShowParticle(int particleID)
        {
            CheckCheckBoxes();

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
        private void ShowRandomParticle()
        {
            CheckCheckBoxes();

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



        protected void CheckBoxThemeType0_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxThemeType0.Checked) Session["theme-type-0"] = true;
            else Session["theme-type-0"] = false;
        }
        protected void CheckBoxThemeType1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxThemeType1.Checked) Session["theme-type-1"] = true;
            else Session["theme-type-1"] = false;
        }
        protected void CheckBoxThemeType2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxThemeType2.Checked) Session["theme-type-2"] = true;
            else Session["theme-type-2"] = false;
        }

        protected void ButtonParticleReload_Click(object sender, EventArgs e)
        {
            if (CheckBoxThemeType0.Checked) Session["theme-type-0"] = true;
            else Session["theme-type-0"] = false;

            if (CheckBoxThemeType1.Checked) Session["theme-type-1"] = true;
            else Session["theme-type-1"] = false;

            if (CheckBoxThemeType2.Checked) Session["theme-type-2"] = true;
            else Session["theme-type-2"] = false;

            //обнуляет сохранённую "частицу"
            Session["particleID"] = -1;

            Response.Redirect("Particles.aspx");
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ReportPartical();
        //}
    }
}
