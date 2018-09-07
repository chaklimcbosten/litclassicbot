using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using litclassicbot.Classes;

namespace litclassicbot
{
    public partial class Particals : System.Web.UI.Page
    {
        private int currentParticalID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowRandomPartical();
        }


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
            string beginPartical = "<div class=\"label-partical-line\"><p>";
            string endPartical = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"label-partical-title\">";
            string endTitle = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelParticalLine.Text = partical;
            //randomParticalButtonText = partical;
            LabelParticalTitle.Text = title;
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
            string beginPartical = "<div class=\"label-poem-partical-line\"><p>";
            string endPartical = "</p></div>";
            // замена символов новой строки на тег, выполняющий это в html
            partical = beginPartical + partical.Replace("\n\r", "</p><p>") + endPartical;
            // создаёт "обёрточный" класс для всего содержания сведения о "частице"
            string beginTitle = "<div class=\"label-partical-title\">";
            string endTitle = "</div>";
            // замена символов новой строки на тег, выполняющий это в html
            title = beginTitle + title.Replace("\n\r", "<br>") + endTitle;
            LabelPoemParticalLine.Text = partical;
            LabelParticalTitle.Text = title;
        }
    }
}