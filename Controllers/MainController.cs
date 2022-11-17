using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;
using ServiceGo.Services;


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

            string msg = new LoginService().Login(acc, conn);
            return msg;
        }

        [HttpPost]
        [Route("signup")]
        public string Signup(Signup acc)
        {

            string msg = new SignupService().Signup(acc, conn);
            return msg;

        }

        [HttpPost]
        [Route("userprofile/update")]
        public string Userprofileupdate(Userprofile acc)
        {

            string msg = new UserprofileService().UpdateUserprofile(acc, conn);
            return msg;

        }

        [HttpPost]
        [Route("userprofile/delete")]
        public string Userprofiledelete(Userprofile acc)
        {

            string msg = new UserprofileService().DeleteUserprofile(acc, conn);
            return msg;

        }


        [HttpPost]
        [Route("userprofile/orderhistory")]
        public string Userorderhistory(Orderhistory acc)
        {

            string data = new OrderhistoryService().orderhistory(acc, conn);
            return data;

        }

        [HttpPost]
        [Route("/booking")]
        public string Booking(Booking acc)
        {

            string data = new BookingService().Book(acc, conn);
            return data;

        }

        [HttpGet]
        [Route("/employeelist")]
        public string Employeelist(Employeelisting acc)
        {

            string data = new EmployeelistingService().Employee_list(acc, conn);
            return data;

        }



        ~MainController()
        {
            conn.Close();
        }

    }
}