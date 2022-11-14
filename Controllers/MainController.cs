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
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {

        public readonly IConfiguration _configuration;
        SqlConnection conn;

        public MainController(IConfiguration configuration)
        {
            _configuration = configuration;
            conn= new dbconnect(_configuration).DBConnect();

        }


        [HttpGet]
        [Route("login")]
        public string Login(Login acc)
        {

            string msg = new login().log(acc,conn);
            return msg;
        }

        [HttpPost]
        [Route("signup")]
        public string Signup(Signup acc)
        {

            string msg = new signup().register(acc,conn);
            return msg;

        }

        ~MainController()
        {
            conn.Close();
        }

    }
}