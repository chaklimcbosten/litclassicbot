using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace litclassicbot.Controllers.DataControllers
{
    public class ConnectParticle:DataController
    {
        private Random randomParticle;

        // --- запрос "частицы" ---
        // запрос случайного Id "частицы"
        public int GetRandomParticleId()
        {
            int particleID = -1;
            int maxParticleID;
            randomParticle = new Random();
            int randomParticleID;

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                // открытие соединения
                currentSQLConnection.Open();

                // первая команда - получение максимального ID таблицы с "частицами"
                SqlCommand getMaxIDParticle = new SqlCommand("GetMaxIDParticle", currentSQLConnection);
                getMaxIDParticle.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader getMaxIDParticleReader = getMaxIDParticle.ExecuteReader();

                getMaxIDParticleReader.Read();

                maxParticleID = getMaxIDParticleReader.GetInt32(0);
                randomParticleID = randomParticle.Next(maxParticleID);

                getMaxIDParticleReader.Close();

                // проверка на валидность ID частицы
                while (particleID == -1)
                {
                    // вторая команда - проверка существования такого ID в таблице "частиц"
                    SqlCommand checkIDParticleCommand = new SqlCommand("CheckIDParticle", currentSQLConnection);
                    checkIDParticleCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    checkIDParticleCommand.Parameters.AddWithValue("@Id", randomParticleID);

                    SqlDataReader checkIdParticleCommandSelectReader = checkIDParticleCommand.ExecuteReader();

                    checkIdParticleCommandSelectReader.Read();

                    if (checkIdParticleCommandSelectReader.GetInt32(0) == 1) particleID = randomParticleID;
                    else randomParticleID = randomParticle.Next(maxParticleID);

                    checkIdParticleCommandSelectReader.Close();
                }

                currentSQLConnection.Close();
            }

            return particleID;
        }
        public int GetRandomParticleId(int authorNum, int themeType)
        {
            int particleID = -1;
            //int particleID = -1;
            int maxParticleID;
            randomParticle = new Random();
            int randomParticleID;

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                // открытие соединения
                currentSQLConnection.Open();

                // первая команда - получение максимального ID таблицы с "частицами"
                SqlCommand getMaxIDParticle =
                    new SqlCommand("GetMaxIDParticle-" + authorNum + "-" + themeType, currentSQLConnection);
                getMaxIDParticle.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader getMaxIDParticleReader = getMaxIDParticle.ExecuteReader();

                getMaxIDParticleReader.Read();

                maxParticleID = getMaxIDParticleReader.GetInt32(0);
                randomParticleID = randomParticle.Next(maxParticleID);

                getMaxIDParticleReader.Close();

                // проверка на валидность ID в подтаблице индексов "частиц"
                while (particleID == -1)
                {
                    // вторая команда - проверка существования такого ID в подтаблице индексов "частиц"
                    SqlCommand checkIDParticleCommand =
                        new SqlCommand("CheckIDParticle-" + authorNum + "-" + themeType, currentSQLConnection);
                    checkIDParticleCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    checkIDParticleCommand.Parameters.AddWithValue("@Id", randomParticleID);

                    SqlDataReader checkIdParticleCommandSelectReader = checkIDParticleCommand.ExecuteReader();

                    checkIdParticleCommandSelectReader.Read();

                    particleID = checkIdParticleCommandSelectReader.GetInt32(0);

                    checkIdParticleCommandSelectReader.Close();

                    if (particleID == -1) randomParticleID = randomParticle.Next(maxParticleID);
                }

                currentSQLConnection.Close();
            }

            return particleID;
        }
        // запрос "частицы" по конкретному Id
        public Dictionary<string, object> GetParticle(string userId, string source, int particleId)
        {
            Dictionary<string, object> particleQueryDictionary = new Dictionary<string, object>();

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                currentSQLConnection.Open();

                SqlCommand selectCommand = new SqlCommand("GetParticle", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@userId", userId);
                selectCommand.Parameters.AddWithValue("@source", source);
                selectCommand.Parameters.AddWithValue("@particleId", particleId);

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();
                particleQueryDictionary.Add("line", currentSelectReader.GetString(0));
                particleQueryDictionary.Add("title", currentSelectReader.GetString(1));
                particleQueryDictionary.Add("indexLastLine", currentSelectReader.GetInt32(2));
                particleQueryDictionary.Add("particleId", currentSelectReader.GetInt32(3));
                particleQueryDictionary.Add("bookId", currentSelectReader.GetInt32(4));
                particleQueryDictionary.Add("sumStrongConnections", currentSelectReader.GetInt32(5));
                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return particleQueryDictionary;
        }
        // запрос названия "частицы" по конкретному Id
        public string GetParticleTitle(int particleId)
        {
            string particleTitle;

            using (SqlConnection currentSQLConnection = new SqlConnection(ConnectionString))
            {
                currentSQLConnection.Open();

                SqlCommand selectCommand = new SqlCommand("GetParticleTitle", currentSQLConnection);
                selectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@Id", particleId);

                SqlDataReader currentSelectReader = selectCommand.ExecuteReader();

                currentSelectReader.Read();
                particleTitle = currentSelectReader.GetString(0);
                currentSelectReader.Close();
                currentSQLConnection.Close();
            }

            return particleTitle;
        }
    }
}