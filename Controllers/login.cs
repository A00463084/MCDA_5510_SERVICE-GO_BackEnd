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
    public class login : Controller
    {
        public string log (Login acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from Users where email='" + acc.email + "' and password='" + acc.password + "'",conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    msg = "Success";
                }

                else
                {
                    msg = "Error";
                }




            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
    }
}
