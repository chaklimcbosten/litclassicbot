using litclassicbot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace litclassicbot
{
    public partial class FirstWebPage : System.Web.UI.Page
    {
        private int currentParticalID = -1;
        private string randomParticalButtonText;
        private string randomPoemParticalButtonText;


        protected void Page_Load(object sender, EventArgs e)
        {
            //ShowRandomPartical();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // кнопка случайная "частица"
        protected void RandomParticalButton_Click(object sender, EventArgs e)
        {
            //Label3.Visible = false;
            //ReportParticalButton.Visible = true;

            ShowRandomPartical();

            LabelWelcome.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelParticalLine.Visible = true;
            LabelParticalTitle.Visible = true;
        }
        // кнопка случайная стихотворная "частица"
        protected void RandomPoemParticalButton_Click(object sender, EventArgs e)
        {
            //Label3.Visible = false;
            //ReportParticalButton.Visible = true;

            ShowRandomPoemPartical();

            LabelWelcome.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelParticalLine.Visible = true;
            LabelParticalTitle.Visible = true;
        }
        // кнопка случайное слово
        protected void RandomWordButton_Click(object sender, EventArgs e)
        {
            //Label3.Visible = false;
            //ReportParticalButton.Visible = true;

            ShowRandomWord();

            LabelWelcome.Visible = false;
            LabelParticalLine.Text = "";
            LabelParticalTitle.Text = "";
            LabelParticalLine.Visible = false;
            LabelParticalTitle.Visible = false;
            LabelWordName.Visible = true;
            LabelWordValue.Visible = true;
        }
        // клавиша сообщить об ошибке
        //protected void ReportParticalButton_Click(object sender, EventArgs e)
        //{
        //    Label1.Text = randomParticalButtonText;
        //    Label2.Text = randomPoemParticalButtonText;

        //    //ReportPartical();
        //}


        private void ShowRandomPartical()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<string> listGetRandomPartical = new List<string>();
            listGetRandomPartical = currentConnection.GetRandomPartical("web");
            string partical = listGetRandomPartical[0];
            string title = listGetRandomPartical[1];
            int indeLastLine = Convert.ToInt32(listGetRandomPartical[2]);
            // для отправки сообщения об ошибке
            currentParticalID = Convert.ToInt32(listGetRandomPartical[3]);
            int bookID = Convert.ToInt32(listGetRandomPartical[4]);
            // замена символов новой строки на тег, выполняющий это в html
            //partical = partical.Replace("\n\r", "<br>");
            partical = partical.Replace("\n\r", "</p><p>");
            // замена символов новой строки на тег, выполняющий это в html
            title = title.Replace("\n\r", "<br>");
            LabelParticalLine.Text = partical;
            randomParticalButtonText = partical;
            LabelParticalTitle.Text = title;
            randomPoemParticalButtonText = title;
        }
        private void ShowRandomPoemPartical()
        {
            BotDBConnect currentConnection = new BotDBConnect();

            currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            List<string> listGetRandomPartical = new List<string>();
            listGetRandomPartical = currentConnection.GetRandomPoemPartical("web");
            string partical = listGetRandomPartical[0];
            string title = listGetRandomPartical[1];
            int indeLastLine = Convert.ToInt32(listGetRandomPartical[2]);
            // для отправки сообщения об ошибке
            currentParticalID = Convert.ToInt32(listGetRandomPartical[3]);
            int bookID = Convert.ToInt32(listGetRandomPartical[4]);
            // замена символов новой строки на тег, выполняющий это в html
            //partical = partical.Replace("\n\r", "<br>");
            partical = partical.Replace("\n\r", "</p><p>");
            // замена символов новой строки на тег, выполняющий это в html
            title = title.Replace("\n\r", "<br>");
            LabelParticalLine.Text = partical;
            randomParticalButtonText = partical;
            LabelParticalTitle.Text = title;
            randomPoemParticalButtonText = title;
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
            // замена символов новой строки на тег, выполняющий это в html
            wordName = wordName.Replace("\n\r", "<br>");
            // замена символов новой строки на тег, выполняющий это в html
            wordValue = wordValue.Replace("\n\r", "<br>");
            LabelWordName.Text = wordName;
            randomParticalButtonText = wordName;
            LabelWordValue.Text = wordValue;
            randomPoemParticalButtonText = wordValue;
        }
        //private void ReportPartical()
        //{
        //    if (currentParticalID != -1)
        //    {
        //        BotDBConnect currentConnection = new BotDBConnect();

        //        currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
        //        currentConnection.WriteNewParticalReportByParticalID(Convert.ToString(currentParticalID));

        //        Label3.Text = "Благодарю за сообщение об ошибке!";
        //        Label3.Visible = true;
        //    }
        //}
    }
}