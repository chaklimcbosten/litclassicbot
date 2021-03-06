﻿using litclassicbot.Dialogs;
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
        private int currentParticlesCount = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            SettingPage();
            GettingTotalStatistics();
            SettingLastActions();
            SettingParticlesCountNotification();
        }


        private void SettingPage()
        {
            if (Request.Browser.Cookies)
            {
                Response.Cookies["litclassic-cookie"]["last-visit"] = DateTime.Now.ToString();
                Response.Cookies["litclassic-cookie"].Expires = DateTime.Now.AddYears(3);
            }
        }
        private void SettingLastActions()
        {
            // если браузер поддерживает cookie
            if (Request.Browser.Cookies)
            {
                // текущая "частица"
                // если есть сведения о "частице" в файле cookie
                if (Request.Cookies["litclassic-cookie-particle"] != null)
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    string title = currentConnection.GetParticleTitle(
                        Convert.ToInt32((Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["particleID"]))));
                    // создаёт "обёрточный" класс для всего содержания сведения о "частице"
                    string beginTitle = "<div class=\"last-action-black-label-particle\"><a class=\"last-action-link\" href=\"Particles.aspx\">";
                    string endTitle = "</a></div>";
                    // замена символов новой строки на тег, выполняющий это в html
                    title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
                    LabelLastParticle.Text = title;
                }
                // если сведений о "частице" в файле cookie нет
                else
                {
                    LabelParticleColumn.Visible = false;
                }

                // текущее слово
                // если есть сведения о слове в файле cookie
                if (Request.Cookies["litclassic-cookie-words"] != null)
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    string name = currentConnection.GetWordName(
                        Convert.ToInt32((Server.HtmlEncode(Request.Cookies["litclassic-cookie-words"]["wordID"]))));
                    // создаёт "обёрточный" класс для всего содержания значения слова
                    string beginWordName = "<div class=\"last-action-black-label-word\"><a class=\"last-action-link\" href=\"Words.aspx\">";
                    string endWordName = "</a></div>";
                    // замена символов новой строки на тег, выполняющий это в html
                    name = beginWordName + name.Replace("\n\r", "<br>") + endWordName;
                    LabelLastWord.Text = name;
                }
                // если сведений о словах в файле cookie нет
                else
                {
                    LabelWordColumn.Visible = false;
                }
            }
            // если браузер не поддерживает cookie
            else
            {
                // текущая "частица"
                // если есть сведения о "частице" в данных сессии
                if (Session["particleID"] != null)
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    string title = currentConnection.GetParticleTitle((int)Session["particleID"]);
                    // создаёт "обёрточный" класс для всего содержания сведения о "частице"
                    string beginTitle = "<div class=\"last-action-black-label-particle\"><a class=\"last-action-link\" href=\"Particles.aspx\">";
                    string endTitle = "</a></div>";
                    // замена символов новой строки на тег, выполняющий это в html
                    title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
                    LabelLastParticle.Text = title;
                }
                // если сведений о "частицах" в данных сессии нет
                else
                {
                    LabelParticleColumn.Visible = false;
                }

                // текущее слово
                // если есть сведения о словах в данных сессии
                if (Session["wordID"] != null)
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    string name = currentConnection.GetWordName((int)Session["wordID"]);
                    // создаёт "обёрточный" класс для всего содержания значения слова
                    string beginWordName = "<div class=\"last-action-black-label-word\"><a class=\"last-action-link\" href=\"Words.aspx\">";
                    string endWordName = "</a></div>";
                    // замена символов новой строки на тег, выполняющий это в html
                    name = beginWordName + name.Replace("\n\r", "<br>") + endWordName;
                    LabelLastWord.Text = name;
                }
                // если сведений о словах в данных сессии нет
                else
                {
                    LabelWordColumn.Visible = false;
                }
            }

            if ((!LabelParticleColumn.Visible) && (!LabelWordColumn.Visible))
                //LabelLastAction.Visible = false;
                LabelLastAction.Text = "<div class=\"content-main-page\"><h2>Впервые на сайте?</h2>" +
                    "<p>Выберите интересующий раздел - \"частиц\" или словаря.</p></div>";
        }
        private void GettingTotalStatistics()
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
                    "{5} " + authors + ". Всего \"частиц\" в базе сайте - {1}. " +
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
                //LabelStatistics.Text = statistic;
            }
            catch
            {
                //LabelStatistics.Text = "<p>Во время загрузки статистики произошёл сбой. " +
                //"Для её отображения можете попробовать обновить страницу.</p>";
            }
        }
        // настройка уведомления о количестве полученных "частиц"
        private void SettingParticlesCountNotification()
        {
            // если браузер поддерживает cookie
            if (Request.Browser.Cookies)
            {
                // particles-count
                if (Request.Cookies["litclassic-cookie-particle"]["particles-count"] != null)
                {
                    LabelParticleNotification.Text = Server.HtmlEncode(Request.Cookies["litclassic-cookie-particle"]["particles-count"]);
                    currentParticlesCount = Convert.ToInt32(LabelParticleNotification.Text);
                }
                else
                {
                    LabelParticleNotification.Text = "1";
                    currentParticlesCount = 1;
                    Response.Cookies["litclassic-cookie-particle"]["particles-count"] = "1";
                }
            }
            // если браузер не поддерживает cookie
            else
            {
                // particles-count
                if (Session["particles-count"] != null)
                {
                    currentParticlesCount = (int)Session["particles-count"];
                    LabelParticleNotification.Text = (string)Session["particles-count"];
                }
                else if (Session["particles-count"] == null)
                {
                    LabelParticleNotification.Text = "1";
                    currentParticlesCount = 1;
                    Session["particles-count"] = 1;
                }
            }
        }
    }
}