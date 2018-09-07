using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace litclassicbot.Dialogs
{
    public class BotDBConnect
    {
        private string sqlConnection;
        private int countParticals;

        private int maxBookID = 81;
        private int maxParticalID = 72885;
        private int maxWordID = 44366;
        private Random randomBook;
        private Random randomPartical;
        private Random randomWord;


        public void SetSQLConnectionToAzureDBLitClassicBooks()
        {
            sqlConnection = "Server=tcp:litclassic.database.windows.net,1433;Initial Catalog=LitClassicBooks;Persist Security Info=False;User ID=goloto;Password=E439KEAgXkE439KEAgXkE439KEAgXk;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public List<string> GetRandomPartical(string currentConversationID)
        {
            string title = "";
            string line = "";
            List<string> listGetRandomPartical = new List<string>();
            int indexLastLine;
            int particalID = -1;
            int bookID;
            // объяdления переменных, связанных с Random
            //randomBook = new Random();
            randomPartical = new Random();
            //randomWord = new Random();
            int randomParticalID = randomPartical.Next(maxParticalID);
            //int randomBookID = randomPartical.Next(maxBookID);
            //int randomWordID = randomWord.Next(maxWordID);         

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                // открытие соединения
                currentSQLConnection.Open();              

                // проверка на валидность ID частицы
                while (particalID == -1)
                {
                    // первая команда - CheckRandomIDPartical
                    SqlCommand checkRandomIdParticalCommand = new SqlCommand("CheckRandomIDPartical", currentSQLConnection);
                    checkRandomIdParticalCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    checkRandomIdParticalCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                    checkRandomIdParticalCommand.Parameters.AddWithValue("@particalID", randomParticalID);
                    //checkRandomIdParticalCommand.Parameters.AddWithValue("@bookID", randomBookID);

                    SqlDataReader checkRandomIdParticalCommandSelectReader = checkRandomIdParticalCommand.ExecuteReader();

                    checkRandomIdParticalCommandSelectReader.Read();

                    if (checkRandomIdParticalCommandSelectReader.GetInt32(0) == 1) particalID = randomParticalID;
                    else randomParticalID = randomPartical.Next(maxParticalID);

                    checkRandomIdParticalCommandSelectReader.Close();
                }

                // вторая команда - GetPartical
                SqlCommand getParticalCommand = new SqlCommand("GetPartical", currentSQLConnection);
                getParticalCommand.CommandType = System.Data.CommandType.StoredProcedure;

                getParticalCommand.Parameters.AddWithValue("@particalID", particalID);

                SqlDataReader getParticalCommandReader = getParticalCommand.ExecuteReader();

                getParticalCommandReader.Read();

                line = getParticalCommandReader.GetString(0);
                title = getParticalCommandReader.GetString(1);                
                indexLastLine = getParticalCommandReader.GetInt32(2);
                particalID = getParticalCommandReader.GetInt32(3);
                bookID = getParticalCommandReader.GetInt32(4);
                listGetRandomPartical.Add(line);
                listGetRandomPartical.Add(title);
                listGetRandomPartical.Add(Convert.ToString(indexLastLine));
                listGetRandomPartical.Add(Convert.ToString(particalID));
                listGetRandomPartical.Add(Convert.ToString(bookID));

                getParticalCommandReader.Close();
                currentSQLConnection.Close();
            }

            return listGetRandomPartical;
        }
        public List<string> GetRandomParticalOld(string currentConversationID)
        {
            string title = "";
            string partical = "";
            List<string> listGetRandomPartical = new List<string>();
            int indexLastLine;
            int particalID;
            int bookID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetRandomPartical", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                title = currentSelectReader.GetString(1);
                partical = currentSelectReader.GetString(0);
                indexLastLine = currentSelectReader.GetInt32(2);
                particalID = currentSelectReader.GetInt32(3);
                bookID = currentSelectReader.GetInt32(4);
                listGetRandomPartical.Add(title);
                listGetRandomPartical.Add(partical);
                listGetRandomPartical.Add(Convert.ToString(indexLastLine));
                listGetRandomPartical.Add(Convert.ToString(particalID));
                listGetRandomPartical.Add(Convert.ToString(bookID));

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listGetRandomPartical;
        }
        public List<string> GetRandomPoemParticalOld(string currentConversationID)
        {
            string title = "";
            string partical = "";
            List<string> listGetRandomPartical = new List<string>();
            int indexLastLine;
            int particalID;
            int bookID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetRandomPoemPartical", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                title = currentSelectReader.GetString(1);
                partical = currentSelectReader.GetString(0);
                indexLastLine = currentSelectReader.GetInt32(2);
                particalID = currentSelectReader.GetInt32(3);
                bookID = currentSelectReader.GetInt32(4);
                listGetRandomPartical.Add(title);
                listGetRandomPartical.Add(partical);
                listGetRandomPartical.Add(Convert.ToString(indexLastLine));
                listGetRandomPartical.Add(Convert.ToString(particalID));
                listGetRandomPartical.Add(Convert.ToString(bookID));

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listGetRandomPartical;
        }
        public List<string> GetRandomPoemPartical(string currentConversationID)
        {
            string title = "";
            string line = "";
            List<string> listGetRandomPoemPartical = new List<string>();
            int indexLastLine;
            int particalID = -1;
            int bookID;
            // объяdления переменных, связанных с Random
            //randomBook = new Random();
            randomPartical = new Random();
            //randomWord = new Random();
            int randomParticalID = randomPartical.Next(maxParticalID);
            //int randomBookID = randomPartical.Next(maxParticalID);
            //int randomWordID = randomWord.Next(maxWordID);         

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                // открытие соединения
                currentSQLConnection.Open();

                // проверка на валидность ID частицы
                while (particalID == -1)
                {
                    // первая команда - CheckRandomIDPartical
                    SqlCommand checkRandomIdParticalCommand = new SqlCommand("CheckRandomIDPoemPartical", currentSQLConnection);
                    checkRandomIdParticalCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    checkRandomIdParticalCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                    checkRandomIdParticalCommand.Parameters.AddWithValue("@particalID", randomParticalID);

                    SqlDataReader checkRandomIdParticalCommandSelectReader = checkRandomIdParticalCommand.ExecuteReader();

                    checkRandomIdParticalCommandSelectReader.Read();

                    if (checkRandomIdParticalCommandSelectReader.GetInt32(0) == 1) particalID = randomParticalID;
                    else randomParticalID = randomPartical.Next(maxParticalID);

                    checkRandomIdParticalCommandSelectReader.Close();
                }

                // вторая команда - GetPartical
                SqlCommand getParticalCommand = new SqlCommand("GetPartical", currentSQLConnection);
                getParticalCommand.CommandType = System.Data.CommandType.StoredProcedure;

                getParticalCommand.Parameters.AddWithValue("@particalID", particalID);

                SqlDataReader getParticalCommandReader = getParticalCommand.ExecuteReader();

                getParticalCommandReader.Read();

                line = getParticalCommandReader.GetString(0);
                title = getParticalCommandReader.GetString(1);
                indexLastLine = getParticalCommandReader.GetInt32(2);
                particalID = getParticalCommandReader.GetInt32(3);
                bookID = getParticalCommandReader.GetInt32(4);
                listGetRandomPoemPartical.Add(line);
                listGetRandomPoemPartical.Add(title);
                listGetRandomPoemPartical.Add(Convert.ToString(indexLastLine));
                listGetRandomPoemPartical.Add(Convert.ToString(particalID));
                listGetRandomPoemPartical.Add(Convert.ToString(bookID));

                getParticalCommandReader.Close();
                currentSQLConnection.Close();
            }

            return listGetRandomPoemPartical;
        }
        public List<string> GetRandomWord(string currentConversationID)
        {
            string name = "";
            string value = "";
            string links = "";
            string firstLetter = "";
            List<string> listGetRandomPartical = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetRandomWord", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                selectCommand.Parameters.AddWithValue("@wordIDMax", maxWordID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                name = currentSelectReader.GetString(0);
                value = currentSelectReader.GetString(1);
                links = currentSelectReader.GetString(2);
                firstLetter = currentSelectReader.GetString(3);

                listGetRandomPartical.Add(name);
                listGetRandomPartical.Add(value);
                listGetRandomPartical.Add(links);
                listGetRandomPartical.Add(firstLetter);

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listGetRandomPartical;
        }
        public List<string> GetTotalStatistics()
        {
            List<string> totalStatistics = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                //SqlCommand selectCommand = new SqlCommand("GetAllFromBooksTotalStatistics", currentSQLConnection);
                SqlCommand selectCommand = new SqlCommand("GetTotalStatistics", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                // booksCount, particalsCount, linesCount, authorsCount, genresCount, preReformsCount, reportsCount, getParticalsCount,
                //favouritesCount, startedBooksCount, usersCount, avgLinesPoemPercent, avgParticalsPoemPercent, avgLinesEntryPercent 11 14
                // получение числа книг (booksCount)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(0)));
                // получение числа частиц (particalsCount)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(1)));
                // получение среднего процента стихотворных строк в книгах (avgLinesPoemPercent)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(2)));
                // получение среднего процента стихотворных строк в частицах (avgParticalsPoemPercent)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(3)));
                // получение среднего процента покрытия частицами книг (avgLinesEntryPercent)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(4)));
                // получение числа авторов (authorsCount)
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(5)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(6)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(7)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(8)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(9)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(10)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(11)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(12)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetInt32(13)));
                totalStatistics.Add(Convert.ToString(currentSelectReader.GetDateTime(14)));

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return totalStatistics;
        }
        public List<string> GetBooksAuthors()
        {
            List<string> listBooksAuthors = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetBooksAuthors", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                // отчего-то первая строка в цикле не читается
                listBooksAuthors.Add(currentSelectReader.GetString(0) + ' ' + currentSelectReader.GetString(1) + ' ' + currentSelectReader.GetString(2));

                if (currentSelectReader.HasRows)
                {
                    while (currentSelectReader.Read())
                    {
                        listBooksAuthors.Add(currentSelectReader.GetString(0) + ' ' + currentSelectReader.GetString(1) + ' ' + currentSelectReader.GetString(2));
                    }
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listBooksAuthors;
        }
        public void WriteNewParticalReportByConversationID(string currentConversationID)
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("WriteNewParticalReport", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);

                currentSQLConnection.Open();
                selectCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void WriteNewParticalReportByParticalID(string currentParticalID)
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("WriteNewParticalReportByParticalID", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@particalID", currentParticalID);

                currentSQLConnection.Open();
                selectCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void WriteNewWordReportByConversationID(string currentConversationID)
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("WriteNewWordReportByConversationID", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);

                currentSQLConnection.Open();
                selectCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void WriteNewWordReportByWordID(string currentWordID)
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("WriteNewWordReportByWordID", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@wordID", currentWordID);

                currentSQLConnection.Open();
                selectCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void WriteNewFavouritePartical(string currentConversationID)
        {
            int favouriteParticalID = GetNewIDFavouritePartical();
            int particalID = GetLastParticalIDFromConversationID(currentConversationID);

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand newLineCommand = new SqlCommand("WriteNewFavouritePartical", currentSQLConnection);
                newLineCommand.CommandType = System.Data.CommandType.StoredProcedure;

                newLineCommand.Parameters.AddWithValue("@Id", favouriteParticalID);
                newLineCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                newLineCommand.Parameters.AddWithValue("@particalID", particalID);

                currentSQLConnection.Open();
                newLineCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void WriteNewFeedbackMessage(string currentConversationID, string feedbackMessage)
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("WriteNewFeedbackMessage", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                selectCommand.Parameters.AddWithValue("@feedbackMessage", feedbackMessage);

                currentSQLConnection.Open();
                selectCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public string[] ReadNext(int indexLastLine, string currentConversationID, int bookID)
        {
            string line;
            string title;
            //int lineID;
            //int bookID;
            string[] readNext = new string[2];

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand newLineCommand = new SqlCommand("ReadNext", currentSQLConnection);
                newLineCommand.CommandType = System.Data.CommandType.StoredProcedure;

                newLineCommand.Parameters.AddWithValue("@bookID", bookID);
                newLineCommand.Parameters.AddWithValue("@lineID", indexLastLine);
                newLineCommand.Parameters.AddWithValue("@conversationID", currentConversationID);
                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = newLineCommand.ExecuteReader();

                currentSelectReader.Read();

                //bookID = currentSelectReader.GetInt32(0);
                //lineID = currentSelectReader.GetInt32(1);
                title = currentSelectReader.GetString(0);
                line = currentSelectReader.GetString(1);

                //readNext[1] = Convert.ToString(bookID);
                //readNext[1] = Convert.ToString(lineID);
                readNext[0] = title;
                readNext[1] = line;

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return readNext;
        }
        public List<string> GetBookLink(int bookID)
        {
            List<string> bookLink = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetBookLink", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@bookID", bookID);
                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                // добавление ссылки на книгу
                bookLink.Add(currentSelectReader.GetString(0));
                // добавление названия книги
                bookLink.Add(currentSelectReader.GetString(1));

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return bookLink;
        }
        public List<string> GetFavourits(string conversationID)
        {
            List<string> listFavourits = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetFavouriteParticals", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", conversationID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                // отчего-то первая строка в цикле не читается
                listFavourits.Add(currentSelectReader.GetString(0) + " " + currentSelectReader.GetString(1) + " " 
                    + currentSelectReader.GetString(2) + ". \n\r *" + currentSelectReader.GetString(3)
                    + "*////" + currentSelectReader.GetInt32(4));

                if (currentSelectReader.HasRows)
                {
                    while (currentSelectReader.Read())
                    {
                        listFavourits.Add(currentSelectReader.GetString(0) + " " + currentSelectReader.GetString(1) + " "
                            + currentSelectReader.GetString(2) + ". \n\r *" + currentSelectReader.GetString(3)
                            + "*////" + currentSelectReader.GetInt32(4));
                    }
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listFavourits;
        }
        public List<int> GetFavouriteParticalsID(int bookID, string conversationID)
        {
            List<int> listFavouriteParticalsID = new List<int>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetFavouriteParticalsByBookID", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@bookID", bookID);
                selectCommand.Parameters.AddWithValue("@conversationID", conversationID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                // отчего-то первая строка в цикле не читается
                listFavouriteParticalsID.Add(currentSelectReader.GetInt32(0));

                if (currentSelectReader.HasRows)
                {
                    while (currentSelectReader.Read())
                    {
                        listFavouriteParticalsID.Add(currentSelectReader.GetInt32(0));
                    }
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return listFavouriteParticalsID;
        }
        public List<string> GetParticalsTitles(List<int> listParticalIDs)
        {
            List<string> particalTitles = new List<string>();

            foreach (int particalID in listParticalIDs)
            {
                using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
                {
                    SqlCommand selectCommand = new SqlCommand("GetParticalTitle", currentSQLConnection);
                    selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    selectCommand.Parameters.AddWithValue("@particalID", particalID);

                    currentSQLConnection.Open();

                    SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                    currentSelectReader.Read();
                    particalTitles.Add(currentSelectReader.GetString(0));
                    currentSelectReader.Close();
                    currentSQLConnection.Close();
                }
            }

            return particalTitles;
        }
        public List<string> GetPartical(int particalID)
        {
            List<string> partical = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetPartical", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@particalID", particalID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();
                // line
                partical.Add(currentSelectReader.GetString(0));
                // title
                partical.Add(currentSelectReader.GetString(1));
                // indexLastLine
                partical.Add(Convert.ToString(currentSelectReader.GetInt32(2)));
                // particalID
                partical.Add(Convert.ToString(currentSelectReader.GetInt32(3)));
                // bookID
                partical.Add(Convert.ToString(currentSelectReader.GetInt32(4)));
                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return partical;
        }
        public List<string> GetWord(int wordID)
        {
            List<string> word = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetWord", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@Id", wordID);

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();
                word.Add(currentSelectReader.GetString(0));
                word.Add(currentSelectReader.GetString(1));
                word.Add(currentSelectReader.GetString(2));
                word.Add(currentSelectReader.GetString(3));
                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return word;
        }
        public void DeleteFavouritePartical(int particalID, string conversationID)
        {
            List<string> partical = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand deleteCommand = new SqlCommand("DeleteFavouritePartical", currentSQLConnection);
                deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;

                deleteCommand.Parameters.AddWithValue("@particalID", particalID);
                deleteCommand.Parameters.AddWithValue("@conversationID", conversationID);

                currentSQLConnection.Open();
                deleteCommand.ExecuteNonQuery();
                currentSQLConnection.Close();
            }
        }
        public void UpdateTotalStatisticsShort()
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                List<string> listUpdateCommands = new List<string>();

                listUpdateCommands.Add("UpdateStatisticFavouritesCount");
                listUpdateCommands.Add("UpdateStatisticGetParticalsCount");
                listUpdateCommands.Add("UpdateStatisticReportsCount");
                listUpdateCommands.Add("UpdateStatisticStartedBooksCount");
                listUpdateCommands.Add("UpdateStatisticUsersCount");

                currentSQLConnection.Open();

                foreach (string updateCommand in listUpdateCommands)
                {
                    SqlCommand newUpdateCommand = new SqlCommand(updateCommand, currentSQLConnection);
                    newUpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    newUpdateCommand.ExecuteNonQuery();
                }

                currentSQLConnection.Close();
            }
        }


        private void GetCountParticals()
        {
            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetCountParticals", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                try
                {
                    countParticals = currentSelectReader.GetInt32(0);
                }
                catch
                {
                    countParticals = 1;
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }
        }
        private int GetNewIDParticalsHistory()
        {
            int particalsHistoryID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetNewIDParticalsHistory", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                try
                {
                    particalsHistoryID = currentSelectReader.GetInt32(0) + 1;
                }
                catch
                {
                    particalsHistoryID = 1;
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }              

            return particalsHistoryID;
        }
        private int GetNewIdParticalsReport()
        {
            int particalsReportID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetNewIDParticalsReport", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                try
                {
                    particalsReportID = currentSelectReader.GetInt32(0) + 1;
                }
                catch
                {
                    particalsReportID = 1;
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return particalsReportID;
        }
        private int GetNewIDFavouritePartical()
        {
            int favouriteParticalID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetNewIDFavouritePartical", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                try
                {
                    favouriteParticalID = currentSelectReader.GetInt32(0) + 1;
                }
                catch
                {
                    favouriteParticalID = 1;
                }

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return favouriteParticalID;
        }
        private int GetLastParticalIDFromConversationID(string conversationID)
        {
            int particalsHistoryID;

            using (SqlConnection currentSQLConnection = new SqlConnection(sqlConnection))
            {
                SqlCommand selectCommand = new SqlCommand("GetLastParticalIDFromConversationID", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@conversationID", conversationID);
                currentSQLConnection.Open();

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                particalsHistoryID = currentSelectReader.GetInt32(0);

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return particalsHistoryID;
        }
    }
}