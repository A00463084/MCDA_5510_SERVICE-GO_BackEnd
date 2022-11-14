using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;


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
            conn= new DbConnect(_configuration).Connect();

        }


        [HttpGet]
        [Route("login")]
        public string Login(Login acc)
        {

            string msg = new LoginController().Login(acc, conn);
            return msg;
        }

        [HttpPost]
        [Route("signup")]
        public string Signup(Signup acc)
        {

            string msg = new SignupController().Signup(acc, conn);
            return msg;

        }

        ~MainController()
        {
            conn.Close();
        }

    }
}