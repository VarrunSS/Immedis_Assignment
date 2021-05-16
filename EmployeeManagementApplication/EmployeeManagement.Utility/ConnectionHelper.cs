using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.Utility
{
    public class ConnectionHelper
    {
        private const string ConnectionString = "Data Source=***;Initial Catalog=***;Integrated Security=True;Application Name=***;";

        public static IDbConnection GetDbContext()
        {
            return new SqlConnection(ConnectionString);
        }

        
    }
}
