using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Utils
{
    public class ConnectionString
    {
        public ConnectionString(string dbConnection)
        {
            DbConnection = dbConnection;
        }
        public string DbConnection { get; set; }
    }
}
