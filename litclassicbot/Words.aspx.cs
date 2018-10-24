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
            ScriptManagerSetup();
            PageSetup();
        }

        // --- настройка необходимого при загрузке страницы --- 
        // регистрация асинхронных запросов в ScriptManager
        private void ScriptManagerSetup()
        {
            // UpdatePanelWordsPage
            ScriptManagerWordsPage.RegisterAsyncPostBackControl(ButtonWordReload);
        }
        // настройка персонализации страницы, если она открывается впервые
        private void PageSetup()
        {
            if (!IsPostBack)
            {
                // если браузер поддерживает cookie
                if (Request.Browser.Cookies)
                {
                    // первое посещение, если cookie не созданы
                    if (Request.Cookies["litclassic-cookie-words"] == null)
                    {
                        Response.Cookies["litclassic-cookie-words"].Expires = DateTime.Now.AddYears(3);

                        SettingNewRandomIdWord();
                        ShowingWord(Session.SessionID, "web", currentWordID);
                    }
                    // cookie-файл существует
                    else
                    {
                        // если cookie-файла с ID "частицы" нет, или этот ID обнулён
                        if ((Server.HtmlEncode(Request.Cookies["litclassic-cookie-words"]["wordID"]) == null))
                        {
                            SettingNewRandomIdWord();
                            ShowingWord(Session.SessionID, "web", currentWordID);

                            Response.Cookies["litclassic-cookie-words"]["wordID"]
                                = Convert.ToString(currentWordID);
                        }
                        // если ID "частицы" задан
                        else
                        {
                            ShowingWord(Session.SessionID, "web", Convert.ToInt32(Server.HtmlEncode(
                                Request.Cookies["litclassic-cookie-words"]["wordID"])));
                        }
                    }
                }
                // если браузер не поддерживает cookie
                else
                {
                    SettingNewRandomIdWord();
                    ShowingWord(Session.SessionID, "web", currentWordID);
                }
            }
        }


        // --- слова ---       
        // запрос случайного Id слова
        private void SettingNewRandomIdWord()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            currentWordID = currentConnection.GetRandomWordId();

            // если браузер поддерживает cookie
            if (Request.Browser.Cookies) Response.Cookies["litclassic-cookie-words"]["wordID"]
                    = Convert.ToString(currentWordID);
            // если браузер не поддерживает cookie
            else Session["wordID"] = currentWordID;
        }
        // запрос слова по заданному Id
        private void ShowingWord(string userId, string source, int wordId)
        {
            BotDBConnect currentConnection = new BotDBConnect();
            Dictionary<string, object> wordQueryDictionary = new Dictionary<string, object>();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            wordQueryDictionary = currentConnection.GetWord(userId, source, wordId);
            string mainWordName = (string)wordQueryDictionary["name"];
            string mainWordValue = (string)wordQueryDictionary["value"];
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginMainWordName = "<div class=\"black-label-word-name\">";
            string endMainWordName = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordName = beginMainWordName + mainWordName.Replace("\n\r", "<br>") + endMainWordName;
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginWordValue = "<div class=\"black-label-main-content\"><p>";
            string endWordValue = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            mainWordValue = beginWordValue + mainWordValue.Replace("\n\r", "<br>") + endWordValue;
            LabelWordValue.Text = mainWordValue;
            LabelWordName.Text = mainWordName;

            // если ключей больше трёх - в значении слова присутствует ссылка
            if (wordQueryDictionary.Keys.Count > 3)
            {
                LabelWordLinks.Visible = true;

                for (int i = 0; i < (int)wordQueryDictionary["linksCount"]; i++)
                {
                    List<string> listWordLink = (List<string>)wordQueryDictionary["link" + i];
                    string subWordName = listWordLink[0];
                    string subWordValue = listWordLink[1];
                    string beginSubWord = "<div class=\"content-main-page\"><p>";
                    string endSubWord = "</p></div>";
                    string subWord = beginSubWord + subWordName + " - "
                        + subWordValue.Replace("\n\r", "<br>") + endSubWord;
                    LabelWordLinks.Text += subWord;
                }
            }
        }


        // --- элементы формы ---
        protected void ButtonWordReload_Click(object sender, EventArgs e)
        {
            LabelWordLinks.Text = "";
            SettingNewRandomIdWord();
            ShowingWord(Session.SessionID, "web", currentWordID);
            UpdatePanelWord.Update();
        }
    }
}