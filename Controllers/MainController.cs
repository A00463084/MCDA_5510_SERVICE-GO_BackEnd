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

            try
            {
                conn = new DbConnect(_configuration).Connect();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        [HttpPost]
        [Route("userprofile/update")]
        public string Userprofileupdate(Userprofile acc)
        {

            string msg = new UserprofileController().UpdateUserprofile(acc, conn);
            return msg;

        }

        [HttpPost]
        [Route("userprofile/delete")]
        public string Userprofiledelete(Userprofile acc)
        {

            string msg = new UserprofileController().DeleteUserprofile(acc, conn);
            return msg;

        }

        ~MainController()
        {
            conn.Close();
        }

    }
}