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
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowRandomWord();
        }


        private void ShowRandomWord()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<string> listGetWord = new List<string>();
            listGetWord = currentConnection.GetRandomWord("web");
            // получение имени слова
            string wordName = listGetWord[0];
            // получение значения слова
            string wordValue = listGetWord[1];
            // получение ссылок слова
            string wordLinks = listGetWord[2];
            // получение первой буквы слова
            // может быть, проще её получать из имени?
            string wordFirstLetter = listGetWord[3];
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginWordName = "<div class=\"label-word-name\">";
            string endWordName = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            wordName = beginWordName + wordName.Replace("\n\r", "<br>") + endWordName;
            // создаёт "обёрточный" класс для всего содержания значения слова
            string beginWordValue = "<div class=\"label-word-value\">";
            string endWordValue = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            wordValue = beginWordValue + wordValue.Replace("\n\r", "<br>") + endWordValue;
            LabelWordValue.Text = wordValue;
            LabelWordName.Text = wordName;
        }
    }
}