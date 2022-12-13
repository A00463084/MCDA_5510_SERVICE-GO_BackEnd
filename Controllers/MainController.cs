using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;
using ServiceGo.Services;


namespace ServiceGo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
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


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login acc)
        {

            ActionResult msg = new LoginService().Login(acc, conn);

            return msg;


        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(Signup acc)
        {

            ActionResult msg = new SignupService().Signup(acc, conn);

            return msg;

        }

        [HttpPost]
        [Route("userprofile/update")]
        public async Task<IActionResult> Userprofileupdate(Userprofile acc)
        {

            ActionResult msg = new UserprofileService().UpdateUserprofile(acc, conn);

            return msg;

        }

        [HttpPost]
        [Route("userprofile/delete")]
        public async Task<IActionResult> Userprofiledelete(Userprofile acc)
        {

            ActionResult msg = new UserprofileService().DeleteUserprofile(acc, conn);

            return msg;


        }


        [HttpPost]
        [Route("userprofile/orderhistory")]
        public async Task<IActionResult> Userorderhistory(Orderhistory acc)
        {

            ActionResult data = new OrderhistoryService().orderhistory(acc, conn);

            return data;

        }

        [HttpPost]
        [Route("/booking")]
        public async Task<IActionResult> Booking(Booking acc)
        {

            ActionResult data = new BookingService().Book(acc, conn);

            return data;

        }

        [HttpPost]
        [Route("bookings/delete")]
        public async Task<IActionResult> DeleteBooking(DeleteBooking acc)
        {

            ActionResult msg = new DeleteBookingService().Delete(acc, conn);

            return msg;
        }

        [HttpGet]
        [Route("/employeelist")]
        public async Task<IActionResult> Employeelist(Employeelisting acc)
        {

            ActionResult data = new EmployeelistingService().Employee_list(acc, conn);

            return data;


        }



        ~MainController()
        {
            conn.Close();
        }

    }
}