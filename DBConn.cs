using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoffeCommerce
{
    public class DBConn
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);
    }
}