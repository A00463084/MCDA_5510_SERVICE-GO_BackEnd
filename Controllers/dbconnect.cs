using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using ServiceGo.Models;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace ServiceGo.Controllers
{
    public class dbconnect : Controller
    {
        public readonly IConfiguration _configuration;

        public dbconnect(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public SqlConnection DBConnect()
        {

            SqlConnection conn = new SqlConnection(connectionString: _configuration.GetConnectionString("DbConn").ToString());
            conn.Open();
            return conn;
        }
    }
}
