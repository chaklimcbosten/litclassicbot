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
            GetTotalStatistics();

            LabelAboutSite.Text = "<p>Вы словно открываете книгу на случайной странице. " +
                "Неизвестная она для Вас и новая ли, читанная, но позабытая ли - её страница хоть чуть-чуть увлекает Вас. " +
                "Нет задачи читать её всю, лишь страницу - развлечь себя. " +
                "Но книга эта не одна, а книг этих вокруг Вас - сотни! " +
                "Не бегая от полки к полки, Вы перебираете одну за другой, открывая для себя новую, увлекаясь ненадолго, " +
                "или вспоминая старую, последнее чтение которой скрылось годами. " +
                "Какая будет следующая книга? На какой части она откроется? Неужели не правдоподобно, " +
                "что именно в следующей \"частице\" может ждать Вас то, что искренне понравится, " +
                "но что скрыто было по неизвестным причинам от Вашего внимания доселе?</p>" +
                "<p>Восстанавливая упущения школьной программы, ценя дорогое, утекающее в дела время, " +
                "здесь не нужно искать книги, знать, какие прочесть в первую очередь, т.к. всё - уже собрано и подготовлено. " +
                "В книгах этих лица русской литературы и русской души - Аксаков, Батюшков, Пушкин, Гоголь, Лермонтов, Достоевский, Одоевский, Державин и другие - " +
                "помогают вспомнить себя и свой труд, посвящённый не силе безначального искусства, " +
                "но человеческому пути к более чистому и светлому состоянию.</p>";            
            LabelNavigation.Text = "<p>В верхней части сайта - \"шапке\" - клавиши навигации и ссылок.</p>" +
                    "<p>В нижней части сайта - \"подвале\" - клавиши вызова основных функций сайта.</p>";
            //LabelStatistics.Text = "";
            LabelGratitudes.Text = "";
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        //protected void RandomParticalButton_Click(object sender, EventArgs e)
        //{
        //    //Label3.Visible = false;
        //    //ReportParticalButton.Visible = true;

        //    ShowRandomPartical();

        //    LabelWelcome1.Visible = false;
        //    LabelWelcome2.Visible = false;
        //    LabelWelcome3.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelParticalLine.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //}
        
        //protected void RandomPoemParticalButton_Click(object sender, EventArgs e)
        //{
        //    //Label3.Visible = false;
        //    //ReportParticalButton.Visible = true;

        //    ShowRandomPoemPartical();

        //    LabelWelcome1.Visible = false;
        //    LabelWelcome2.Visible = false;
        //    LabelWelcome3.Visible = false;
        //    LabelWordName.Visible = false;
        //    LabelWordValue.Visible = false;
        //    LabelParticalLine.Visible = false;
        //    LabelWordName.Text = "";
        //    LabelWordValue.Text = "";
        //    LabelPoemParticalLine.Visible = true;
        //    LabelParticalTitle.Visible = true;
        //}
        
        //protected void RandomWordButton_Click(object sender, EventArgs e)
        //{
        //    //Label3.Visible = false;
        //    //ReportParticalButton.Visible = true;

        //    ShowRandomWord();

        //    LabelWelcome1.Visible = false;
        //    LabelWelcome2.Visible = false;
        //    LabelWelcome3.Visible = false;
        //    LabelParticalLine.Text = "";
        //    LabelParticalTitle.Text = "";
        //    LabelParticalLine.Visible = false;
        //    LabelParticalTitle.Visible = false;
        //    LabelPoemParticalLine.Visible = false;
        //    LabelWordName.Visible = true;
        //    LabelWordValue.Visible = true;
        //}
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
            // создаёт "обёрточный" класс для всего содержания "частицы"
            string beginPartical = "<div class=\"label-partical-line\">";
            string endPartical = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"label-partical-title\">";
            string endTitle = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelParticalLine.Text = partical;
            randomParticalButtonText = partical;
            LabelParticalTitle.Text = title;
            randomPoemParticalButtonText = title;
            LabelSubtitleMain.Text = "Случайная \"частица\"";
            LabelSubtitleParticalLine.Text = "\"Частица\"";
            LabelSubtitleParticalTitle.Text = "Сведения о \"частице\"";
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
            // создаёт "обёрточный" класс для всего содержания "частицы"
            string beginPartical = "<div class=\"label-poem-partical-line\">";
            string endPartical = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"label-partical-title\">";
            string endTitle = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelPoemParticalLine.Text = partical;
            randomParticalButtonText = partical;
            LabelParticalTitle.Text = title;
            randomPoemParticalButtonText = title;
            LabelSubtitleMain.Text = "Случайная стихотворная \"частица\"";
            LabelSubtitleParticalLine.Text = "\"Частица\"";
            LabelSubtitleParticalTitle.Text = "Сведения о \"частице\"";
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
            LabelWordName.Text = wordName;
            randomParticalButtonText = wordName;
            LabelWordValue.Text = wordValue;
            randomPoemParticalButtonText = wordValue;
            LabelSubtitleMain.Text = "Случайное слово из толкового словаря живого, великорусского языка Владимира Ивановича Даля";
            LabelSubtitleParticalLine.Text = "Слово";
            LabelSubtitleParticalTitle.Text = "Значение слова";
        }

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

                string particalCall;

                // если предпоследнее число - 1
                if ((listGetTtotalStatistics[7].Length > 1)
                    && (listGetTtotalStatistics[7][listGetTtotalStatistics[0].Count() - 2] == '1')) particalCall = "раз";
                // проверка последнего числа
                else if ((listGetTtotalStatistics[7].Last() == '1')
                    | (listGetTtotalStatistics[7].Last() == '0')) particalCall = "раз";
                else particalCall = "раза";

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
                    "<p>{7} " + particalCall + " была вызвана команда получения случайной \"частицы\". " +
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
        protected void ImageButtonPartical_Click(object sender, ImageClickEventArgs e)
        {
            ShowRandomPartical();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelPoemParticalLine.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelParticalLine.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelParticalTitle.Visible = true;
        }

        // кнопка случайная стихотворная "частица"
        protected void ImageButtonPoemPartical_Click(object sender, ImageClickEventArgs e)
        {
            ShowRandomPoemPartical();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelParticalLine.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelPoemParticalLine.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelParticalTitle.Visible = true;
        }
        // кнопка случайное слово
        protected void ImageButtonWord_Click(object sender, ImageClickEventArgs e)
        {
            ShowRandomWord();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelParticalLine.Text = "";
            LabelParticalTitle.Text = "";
            LabelParticalLine.Visible = false;
            LabelParticalTitle.Visible = false;
            LabelPoemParticalLine.Visible = false;
            LabelWordName.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelWordValue.Visible = true;
        }


        protected void LinkButtonMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void LinkButtonVKPublic_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://vk.com/litclassic");
        }

        protected void LinkButtonTelegramBot_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://t.me/litclassicbot");
        }

        protected void LinkButtonAuthorization_Click(object sender, EventArgs e)
        {

        }


        protected void ButtonPartical_Click(object sender, EventArgs e)
        {
            ShowRandomPartical();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelPoemParticalLine.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelParticalLine.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelParticalTitle.Visible = true;
        }


        protected void ButtonPoemPartical_Click(object sender, EventArgs e)
        {
            ShowRandomPoemPartical();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelWordName.Visible = false;
            LabelWordValue.Visible = false;
            LabelParticalLine.Visible = false;
            LabelWordName.Text = "";
            LabelWordValue.Text = "";
            LabelPoemParticalLine.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelParticalTitle.Visible = true;
            //ButtonPoemPartical.BackColor = whitesmoke;
        }


        protected void ButtonWord_Click(object sender, EventArgs e)
        {
            ShowRandomWord();

            LabelSubtitleAboutSite.Visible = false;
            LabelAboutSite.Visible = false;
            LabelSubtitleNavigation.Visible = false;
            LabelNavigation.Visible = false;
            LabelSubtitleStatistics.Visible = false;
            LabelStatistics.Visible = false;
            LabelSubtitleGratitudes.Visible = false;
            LabelGratitudes.Visible = false;
            LabelParticalLine.Text = "";
            LabelParticalTitle.Text = "";
            LabelParticalLine.Visible = false;
            LabelParticalTitle.Visible = false;
            LabelPoemParticalLine.Visible = false;
            LabelWordName.Visible = true;
            LabelSubtitleParticalTitle.Visible = true;
            LabelWordValue.Visible = true;
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