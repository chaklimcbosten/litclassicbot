using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace litclassicbot.Controllers.DataControllers
{
    public class ConnectWord:DataController
    {
        // --- запрос слова ---
        // запрос случайного Id слова
        public int GetRandomWordId()
        {
            int wordID = -1;
            int maxWordID;
            Random randomWord = new Random();
            int randomWordID;

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                // открытие соединения
                currentSQLConnection.Open();

                // первая команда - получение максимального ID таблицы с "частицами"
                SqlCommand getMaxIDWord = new SqlCommand("GetMaxIDWord", currentSQLConnection);
                getMaxIDWord.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader getMaxIDWordReader = getMaxIDWord.ExecuteReader();

                getMaxIDWordReader.Read();

                maxWordID = getMaxIDWordReader.GetInt32(0);
                randomWordID = randomWord.Next(maxWordID);

                getMaxIDWordReader.Close();

                // проверка на валидность ID частицы
                while (wordID == -1)
                {
                    // вторая команда - проверка существования такого ID в таблице "частиц"
                    SqlCommand checkIDWordCommand = new SqlCommand("CheckIDWord", currentSQLConnection);
                    checkIDWordCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    checkIDWordCommand.Parameters.AddWithValue("@Id", randomWordID);

                    SqlDataReader checkIdWordCommandSelectReader = checkIDWordCommand.ExecuteReader();

                    checkIdWordCommandSelectReader.Read();

                    if (checkIdWordCommandSelectReader.GetInt32(0) == 1) wordID = randomWordID;
                    else randomWordID = randomWord.Next(maxWordID);

                    checkIdWordCommandSelectReader.Close();
                }

                currentSQLConnection.Close();
            }

            return wordID;
        }
        // запрос слова по конкретному Id
        public Dictionary<string, object> GetWord(string userId, string source, int wordId)
        {
            string links = "";
            Dictionary<string, object> wordQueryDictionary = new Dictionary<string, object>();

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                currentSQLConnection.Open();

                SqlCommand selectCommand = new SqlCommand("GetWord", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@wordId", wordId);
                selectCommand.Parameters.AddWithValue("@userId", userId);
                selectCommand.Parameters.AddWithValue("@source", source);

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                wordQueryDictionary.Add("name", currentSelectReader.GetString(0));
                wordQueryDictionary.Add("value", currentSelectReader.GetString(1));
                links = currentSelectReader.GetString(2);
                wordQueryDictionary.Add("firstLetter", currentSelectReader.GetString(3));

                currentSelectReader.Close();
                currentSQLConnection.Close();

                // есть ли вообще ссылки
                if (links != "-1")
                {
                    string[] linksMassive = links.Split(';');
                    List<int> listLinks = new List<int>();
                    int linksCount = linksMassive.Length - 1;

                    // добавление числа ссылок в словарь
                    wordQueryDictionary.Add("linksCount", linksCount);

                    // заполнение списка ссылок всеми элементами кроме последнего - пустого,
                    // а также проверка на повторяемость ссылок
                    for (int iLinks = 0; iLinks < linksCount; iLinks++)
                    {
                        if (listLinks.IndexOf(Convert.ToInt32(linksMassive[iLinks])) == -1)
                        {
                            listLinks.Add(Convert.ToInt32(linksMassive[iLinks]));
                        }
                    }

                    // создание списков слов по ссылкам
                    for (int iLink = 0; iLink < linksCount; iLink++)
                    {
                        List<string> listWord = new List<string>();
                        listWord = GetWordOld(listLinks[iLink]);

                        wordQueryDictionary.Add("link" + iLink, listWord);
                    }

                }
            }

            return wordQueryDictionary;
        }
        // запрос слова (только самого слова) по конкретному Id
        public string GetWordName(int wordId)
        {
            string name;

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                currentSQLConnection.Open();

                SqlCommand selectCommand = new SqlCommand("GetWordName", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@wordId", wordId);

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();

                name = currentSelectReader.GetString(0);

                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return name;
        }
        // not root
        public List<string> GetWordOld(int wordID)
        {
            List<string> word = new List<string>();

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                currentSQLConnection.Open();

                SqlCommand selectCommand = new SqlCommand("GetWordOld", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@Id", wordID);

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
    }
}