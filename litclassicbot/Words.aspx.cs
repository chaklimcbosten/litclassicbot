using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using litclassicbot.Classes;

namespace litclassicbot
{
    public partial class Words : System.Web.UI.Page
    {
        private int currentWordID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManagerSetting();
            PageSetting();
        }


        private void ScriptManagerSetting()
        {
            // UpdatePanelWordsPage
            ScriptManagerWordsPage.RegisterAsyncPostBackControl(ButtonWordReload);
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
                    if (Request.Cookies["litclassic-cookie-words"] == null)
                    {
                        Response.Cookies["litclassic-cookie-words"].Expires = DateTime.Now.AddYears(3);

                        SetNewRandomIDWord();
                        ShowWord(currentWordID);
                    }
                    // cookie-файл существует
                    else
                    {
                        // если cookie-файла с ID "частицы" нет, или этот ID обнулён
                        if ((Server.HtmlEncode(Request.Cookies["litclassic-cookie-words"]["wordID"]) == null))
                        {
                            SetNewRandomIDWord();
                            ShowWord(currentWordID);

                            Response.Cookies["litclassic-cookie-words"]["wordID"]
                                = Convert.ToString(currentWordID);
                        }
                        // если ID "частицы" задан
                        else
                        {
                            ShowWord(Convert.ToInt32(Server.HtmlEncode(
                                Request.Cookies["litclassic-cookie-words"]["wordID"])));
                        }
                    }
                }
                // если браузер не поддерживает cookie
                else
                {
                    SetNewRandomIDWord();
                    ShowWord(currentWordID);
                }
            }
        }
        private void SetNewRandomIDWord()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            currentWordID = currentConnection.GetRandomWordID();

            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) Response.Cookies["litclassic-cookie-words"]["wordID"]
                    = Convert.ToString(currentWordID);
            // если браузер не поддерживает cookie
            else Session["wordID"] = currentWordID;
        }
        private void ShowWord(int currentWordID)
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<List<string>> listListsGetRandomWord = new List<List<string>>();
            listListsGetRandomWord = currentConnection.GetWord("web", currentWordID);
            // получение имени слова
            string mainWordName = listListsGetRandomWord[0][0];
            // получение значения слова
            string mainWordValue = listListsGetRandomWord[0][1];
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginMainWordName = "<div class=\"label-word-name\">";
            string endMainWordName = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordName = beginMainWordName + mainWordName.Replace("\n\r", "<br>") + endMainWordName;
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginWordValue = "<div class=\"label-word-value\">";
            string endWordValue = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordValue = beginWordValue + mainWordValue.Replace("\n\r", "<br>") + endWordValue;
            LabelWordValue.Text = mainWordValue;
            LabelWordName.Text = mainWordName;

            if (listListsGetRandomWord.Count > 1)
            {
                LabelWordLinks.Visible = true;

                for (int i = 1; i < listListsGetRandomWord.Count; i++)
                {
                    string subWordName = listListsGetRandomWord[i][0];
                    string subWordValue = listListsGetRandomWord[i][1];
                    string beginSubWord = "<div class=\"content-main-page\"><p>";
                    string endSubWord = "</p></div>";
                    string subWord = beginSubWord + subWordName + " - "
                        + subWordValue.Replace("\n\r", "<br>") + endSubWord;
                    //string subWord = "<h2>" + subWordName + "</h2>" + beginWordValue + subWordValue + endWordValue;
                    LabelWordLinks.Text += subWord;
                }
            }
        }
        private void ShowRandomWord()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<List<string>> listListsGetRandomWord = new List<List<string>>();
            //List<string> listGetWord = new List<string>();
            listListsGetRandomWord = currentConnection.GetRandomWord("web");
            // получение имени слова
            string mainWordName = listListsGetRandomWord[0][0];
            // получение значения слова
            string mainWordValue = listListsGetRandomWord[0][1];
            // получение ссылок слова
            //string wordLinks = listListsGetRandomWord[0][2];
            // получение первой буквы слова
            // может быть, проще её получать из имени?
            //string wordFirstLetter = listListsGetRandomWord[0][3];
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginMainWordName = "<div class=\"label-word-name\">";
            string endMainWordName = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordName = beginMainWordName + mainWordName.Replace("\n\r", "<br>") + endMainWordName;
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginWordValue = "<div class=\"label-word-value\">";
            string endWordValue = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordValue = beginWordValue + mainWordValue.Replace("\n\r", "<br>") + endWordValue;
            LabelWordValue.Text = mainWordValue;
            LabelWordName.Text = mainWordName;

            if (listListsGetRandomWord.Count > 1)
            {
                LabelWordLinks.Visible = true;

                for (int i = 1; i < listListsGetRandomWord.Count; i++) 
                {
                    string subWordName = listListsGetRandomWord[i][0];
                    string subWordValue = listListsGetRandomWord[i][1];
                    string beginSubWord = "<div class=\"content-main-page\"><p>";
                    string endSubWord = "</p></div>";
                    string subWord = beginSubWord + subWordName + " - "
                        + subWordValue.Replace("\n\r", "<br>") + endSubWord;
                    //string subWord = "<h2>" + subWordName + "</h2>" + beginWordValue + subWordValue + endWordValue;
                    LabelWordLinks.Text += subWord;
                }
            }
        }

        protected void ButtonWordReload_Click(object sender, EventArgs e)
        {
            LabelWordLinks.Text = "";
            SetNewRandomIDWord();
            ShowWord(currentWordID);
            UpdatePanelWord.Update();
        }
    }
}