using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Controllers.DataControllers
{
    public class DataController
    {
        private string connectionString;

        public DataController()
        {
            connectionString = "Server=tcp:litclassic.database.windows.net,1433;" +
                "Initial Catalog=LitClassicBooks;Persist Security Info=False;" +
                "User ID=goloto;Password=9zJUuVMf5yyMTSm5+XybAQNKtac$-@6%!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}