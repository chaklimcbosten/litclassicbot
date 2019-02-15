using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes.Connect
{
    public class Connect
    {
        private string sqlConnection;

        public Connect()
        {
            sqlConnection = "Server=tcp:litclassic.database.windows.net,1433;" +
                "Initial Catalog=LitClassicBooks;Persist Security Info=False;" +
                "User ID=goloto;Password=9zJUuVMf5yyMTSm5+XybAQNKtac$-@6%!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public void SetSQLConnectionToAzureDBLitClassicBooks()
        {
            sqlConnection = "Server=tcp:litclassic.database.windows.net,1433;" +
                "Initial Catalog=LitClassicBooks;Persist Security Info=False;" +
                "User ID=goloto;Password=9zJUuVMf5yyMTSm5+XybAQNKtac$-@6%!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}