using litclassicbot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using litclassicbot.Classes;

namespace litclassicbot
{
    public partial class _Default : Page
    {
        public string copyToClipboard = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTotalStatistics();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //private void ShowRandomPartical()
        //{
        //    BotDBConnect currentConnection = new BotDBConnect();

        //    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

        //    List<string> listGetRandomPartical = new List<string>();
        //    listGetRandomPartical = currentConnection.GetRandomPartical("web");
        //    string partical = listGetRandomPartical[0];
        //    string title = listGetRandomPartical[1];
        //    int indeLastLine = Convert.ToInt32(listGetRandomPartical[2]);
        //    // для отправки сообщения об ошибке
        //    currentParticalID = Convert.ToInt32(listGetRandomPartical[3]);
        //    int bookID = Convert.ToInt32(listGetRandomPartical[4]);
        //    // создаёт "обёрточный" класс для всего содержания "частицы"
        //    string beginPartical = "<div class=\"label-partical-line\"><p>";
        //    string endPartical = "</p></div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
        //    // создаёт "обёрточный" класс для всего содержания сведения о "частице"
        //    string beginTitle = "<div class=\"label-partical-title\">";
        //    string endTitle = "</div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
        //    LabelParticalLine.Text = partical;
        //    randomParticalButtonText = partical;
        //    LabelParticalTitle.Text = title;
        //    randomPoemParticalButtonText = title;
        //    LabelSubtitleMain.Text = "Случайная \"частица\"";
        //    LabelSubtitleParticalLine.Text = "\"Частица\"";
        //    LabelSubtitleParticalTitle.Text = "Сведения о \"частице\"";
        //    LabelToCopy.Text = "<div id=\"ltc\">\"Частица\":\n" + partical + "\nСведения о \"частице\":\n" + title + "</div>";
        //    copyToClipboard = "\"Частица\":\n" + partical + "\nСведения о \"частице\":\n" + title;
        //}
        //private void ShowRandomPoemPartical()
        //{
        //    BotDBConnect currentConnection = new BotDBConnect();

        //    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

        //    List<string> listGetRandomPartical = new List<string>();
        //    listGetRandomPartical = currentConnection.GetRandomPoemPartical("web");
        //    string partical = listGetRandomPartical[0];
        //    string title = listGetRandomPartical[1];
        //    int indeLastLine = Convert.ToInt32(listGetRandomPartical[2]);
        //    // для отправки сообщения об ошибке
        //    currentParticalID = Convert.ToInt32(listGetRandomPartical[3]);
        //    int bookID = Convert.ToInt32(listGetRandomPartical[4]);
        //    // создаёт "обёрточный" класс для всего содержания "частицы"
        //    string beginPartical = "<div class=\"label-poem-partical-line\"><p>";
        //    string endPartical = "</p></div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
        //    // создаёт "обёрточный" класс для всего содержания сведения о "частице"
        //    string beginTitle = "<div class=\"label-partical-title\">";
        //    string endTitle = "</div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
        //    LabelPoemParticalLine.Text = partical;
        //    randomParticalButtonText = partical;
        //    LabelParticalTitle.Text = title;
        //    randomPoemParticalButtonText = title;
        //    LabelSubtitleMain.Text = "Случайная стихотворная \"частица\"";
        //    LabelSubtitleParticalLine.Text = "\"Частица\"";
        //    LabelSubtitleParticalTitle.Text = "Сведения о \"частице\"";
        //}
        //private void ShowRandomWord()
        //{
        //    BotDBConnect currentConnection = new BotDBConnect();

        //    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

        //    List<string> listGetWord = new List<string>();
        //    listGetWord = currentConnection.GetRandomWord("web");
        //    // получение имени слова
        //    string wordName = listGetWord[0];
        //    // получение значения слова
        //    string wordValue = listGetWord[1];
        //    // получение ссылок слова
        //    string wordLinks = listGetWord[2];
        //    // получение первой буквы слова
        //    // может быть, проще её получать из имени?
        //    string wordFirstLetter = listGetWord[3];
        //    // создаёт "обёрточный" класс для всего содержания значения слова
        //    string beginWordName = "<div class=\"label-word-name\">";
        //    string endWordName = "</div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    wordName = beginWordName + wordName.Replace("\n\r", "<br>") + endWordName;
        //    // создаёт "обёрточный" класс для всего содержания значения слова
        //    string beginWordValue = "<div class=\"label-word-value\">";
        //    string endWordValue = "</div>";
        //    // замена символов новой строки на тег, выполняющий это в html
        //    wordValue = beginWordValue + wordValue.Replace("\n\r", "<br>") + endWordValue;
        //    LabelWordName.Text = wordName;
        //    randomParticalButtonText = wordName;
        //    LabelWordValue.Text = wordValue;
        //    randomPoemParticalButtonText = wordValue;
        //    LabelSubtitleMain.Text = "Случайное слово из толкового словаря живого, великорусского языка Владимира Ивановича Даля";
        //    LabelSubtitleParticalLine.Text = "Слово";
        //    LabelSubtitleParticalTitle.Text = "Значение слова";
        //}

        private void GetTotalStatistics()
        {
            try
            {
                BotDBConnect currentConnection = new BotDBConnect();

                currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                List<string> listGetTtotalStatistics = new List<string>();
                listGetTtotalStatistics = currentConnection.GetTotalStatistics();
                string books;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[0].Length > 1) 
                    && (listGetTtotalStatistics[0][listGetTtotalStatistics[0].Count() - 2] == '1')) books = "книг";
                // проверка последнего числа
                else if (listGetTtotalStatistics[0].Last() == '1') books = "книгу";
                else if ((listGetTtotalStatistics[0].Last() == '2')
                    | (listGetTtotalStatistics[0].Last() == '3')
                    | (listGetTtotalStatistics[0].Last() == '4')) books = "книги";
                else books = "книг";

                string authors;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[5].Length > 1)
                    && (listGetTtotalStatistics[5][listGetTtotalStatistics[0].Count() - 2] == '1')) authors = "русских авторов";
                // проверка последнего числа
                else if (listGetTtotalStatistics[5].Last() == '1') authors = "русского автора";
                else authors = "русских авторов";

                string particleCall;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[7].Length > 1)
                    && (listGetTtotalStatistics[7][listGetTtotalStatistics[0].Count() - 2] == '1')) particleCall = "раз";
                // проверка последнего числа
                else if ((listGetTtotalStatistics[7].Last() == '2')
                    | (listGetTtotalStatistics[7].Last() == '3')
                    | (listGetTtotalStatistics[7].Last() == '4')) particleCall = "раза";
                else particleCall = "раз";

                string errors;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[6].Length > 1)
                    && (listGetTtotalStatistics[6][listGetTtotalStatistics[0].Count() - 2] == '1')) errors = "раз";
                // проверка последнего числа
                else if ((listGetTtotalStatistics[6].Last() == '1')
                    | (listGetTtotalStatistics[6].Last() == '0')) errors = "раз";
                else if ((listGetTtotalStatistics[6] == "2")
                    | (listGetTtotalStatistics[6] == "3")
                    | (listGetTtotalStatistics[6] == "4")) errors = "раза";
                else if (listGetTtotalStatistics[6].Length == 1) errors = "раз";
                else errors = "раза";

                string favourites;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[8].Length > 1)
                    && (listGetTtotalStatistics[8][listGetTtotalStatistics[0].Count() - 2] == '1')) favourites = "\"частиц\"";
                // проверка последнего числа
                else if (listGetTtotalStatistics[8].Last() == '1') favourites = "\"частица\"";
                else if ((listGetTtotalStatistics[8].Last() == '2')
                    | (listGetTtotalStatistics[8].Last() == '3')
                    | (listGetTtotalStatistics[8].Last() == '4')) favourites = "\"частицы\"";
                else favourites = "\"частиц\"";

                string users;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[10].Length > 1)
                    && (listGetTtotalStatistics[10][listGetTtotalStatistics[0].Count() - 2] == '1')) users = "пользователей";
                // проверка последнего числа
                else if (listGetTtotalStatistics[10].Last() == '1') users = "пользователь";
                else if ((listGetTtotalStatistics[10].Last() == '2')
                    | (listGetTtotalStatistics[10].Last() == '3')
                    | (listGetTtotalStatistics[10].Last() == '4')) users = "пользователя";
                else users = "пользователей";

                string statistic = String.Format("<p>При составлении \"частиц\" сайт использует {0} " + books + " " +
                    "{5} " + authors +". Всего \"частиц\" в базе сайте - {1}. " +
                    "Эти \"частицы\" покрывают {2}% общего содержания используемых книг. " +
                    "Стихов в книгах от их общего содержания - примерно {3}%. " +
                    "Стихотворных \"частиц\" от общего числа \"частиц\" - {4}%.</p> " +
                    "<p>{7} " + particleCall + " была вызвана команда получения случайной \"частицы\". " +
                    "Функцией сообщения о найденных ошибках воспользовались {6} " + errors + ". " +
                    "{8} " + favourites + " было добавлено в список \"избранных\".</p>" +
                    "<p>Ботом в Telegram воспользовались {10} " + users + ".</p>" +
                    "<p>Статистика же была обновлена в последний раз {11}.</p>",
                    listGetTtotalStatistics[0], listGetTtotalStatistics[1], listGetTtotalStatistics[13], 
                    listGetTtotalStatistics[11], listGetTtotalStatistics[12], listGetTtotalStatistics[3],
                        
                    listGetTtotalStatistics[6], listGetTtotalStatistics[7], listGetTtotalStatistics[8], 
                    listGetTtotalStatistics[9], listGetTtotalStatistics[10], 
                    
                    listGetTtotalStatistics[14]);
                LabelStatistics.Text = statistic;
            }
            catch
            {
                LabelStatistics.Text = "<p>Во время загрузки статистики произошёл сбой. " +
                    "Для её отображения можете попробовать обновить страницу.</p>";
            }
        }

        // кнопка случайная "частица"
        //protected void ImageButtonPartical_Click(object sender, ImageClickEventArgs e)
        //{
        //    ShowRandomPartical();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelParticalLine.Visible = true;
        //    LabelSubtitleParticalLine.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //}

        //// кнопка случайная стихотворная "частица"
        //protected void ImageButtonPoemPartical_Click(object sender, ImageClickEventArgs e)
        //{
        //    ShowRandomPoemPartical();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelPoemParticalLine.Visible = true;
        //    LabelSubtitleParticalLine.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //}
        //// кнопка случайное слово
        //protected void ImageButtonWord_Click(object sender, ImageClickEventArgs e)
        //{
        //    ShowRandomWord();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelParticalLine.Text = "";
        //    LabelParticalTitle.Text = "";
        //    LabelParticalLine.Visible = false;
        //    LabelParticalTitle.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelWordValue.Visible = true;
        //}
        //// кнопка копировать в буфер обмена
        //protected void ImageButtonCopyToClipboard_Click(object sender, ImageClickEventArgs e)
        //{

        //}


        protected void LinkButtonMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://litclassic.com");
        }

        //protected void LinkButtonVKPublic_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://vk.com/litclassic");
        //}

        //protected void LinkButtonTelegramBot_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://t.me/litclassicbot");
        //}

        //protected void LinkButtonAuthorization_Click(object sender, EventArgs e)
        //{

        //}


        //protected void ButtonPartical_Click(object sender, EventArgs e)
        //{
        //    ShowRandomPartical();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelParticalLine.Visible = true;
        //    LabelSubtitleParticalLine.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //}


        //protected void ButtonPoemPartical_Click(object sender, EventArgs e)
        //{
        //    ShowRandomPoemPartical();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelPoemParticalLine.Visible = true;
        //    LabelSubtitleParticalLine.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //    //ButtonPoemPartical.BackColor = whitesmoke;
        //}


        //protected void ButtonWord_Click(object sender, EventArgs e)
        //{
        //    ShowRandomWord();

        //    LabelSubtitleAboutSite.Visible = false;
        //    LabelAboutSite.Visible = false;
        //    LabelSubtitlePartical.Visible = false;
        //    LabelPartical.Visible = false;
        //    LabelSubtitleNavigation.Visible = false;
        //    LabelNavigation.Visible = false;
        //    LabelSubtitleStatistics.Visible = false;
        //    LabelStatistics.Visible = false;
        //    LabelSubtitleGratitudes.Visible = false;
        //    LabelGratitudes.Visible = false;
        //    LabelParticalLine.Text = "";
        //    LabelParticalTitle.Text = "";
        //    LabelParticalLine.Visible = false;
        //    LabelParticalTitle.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Visible = true;
        //    LabelSubtitleParticalTitle.Visible = true;
        //    LabelWordValue.Visible = true;
        //}

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