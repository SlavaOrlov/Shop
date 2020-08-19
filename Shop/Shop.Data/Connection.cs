using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shop.Data
{
    static class Connection
    {
        public static IDbConnection GetConnection()
        {
            string connectionString = @"Data Source=booorlov;Initial Catalog=ElectronicsStore;Integrated Security=True";
            IDbConnection connection = new SqlConnection(connectionString);
            return connection;
        }

    }
}
