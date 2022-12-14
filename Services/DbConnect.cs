using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ServiceGo.Services
{
    public class DbConnect
    {
        public readonly IConfiguration _configuration;

        public DbConnect(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(connectionString: _configuration.GetConnectionString("DbConn").ToString());
            conn.Open();
            return conn;
        }
    }
}
