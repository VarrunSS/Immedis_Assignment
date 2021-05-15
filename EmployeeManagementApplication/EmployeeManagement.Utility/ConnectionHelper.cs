using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.Utility
{
    public class ConnectionHelper
    {
        private const string ConnectionString = "Data Source=USCHWSQL1056D;Initial Catalog=DEV_INTELLIGENCE_WEB;Integrated Security=True;Application Name=Campaign Manager Dev;";

        public static IDbConnection GetDbContext()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
