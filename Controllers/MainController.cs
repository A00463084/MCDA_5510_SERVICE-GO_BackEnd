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


        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(Login acc)
        {

            string msg = new LoginService().Login(acc, conn);

            if(msg == "User Login Successful")
            {
                return Ok(new { status = msg });
            }
            else if(msg == "Login Error")
            {
                return BadRequest(new { status = msg });
            }
            else
            {
                return BadRequest(new { status = msg });
            }

            
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(Signup acc)
        {

            string msg = new SignupService().Signup(acc, conn);

            if (msg == "User Signup Successful")
            {
                return Ok(new { status = msg });
            }
            else if (msg == "Signup Error")
            {
                return BadRequest(new { status = msg });
            }
            else
            {
                return BadRequest(new { status = msg });
            }

        }

        [HttpPost]
        [Route("userprofile/update")]
        public async Task<IActionResult> Userprofileupdate(Userprofile acc)
        {

            string msg = new UserprofileService().UpdateUserprofile(acc, conn);

            if (msg == "Update User Profile")
            {
                return Ok(new { status = msg });
            }
            else if (msg == "Update Failed, User Account Doesn't Exist")
            {
                return BadRequest(new { status = msg });
            }
            else
            {
                return BadRequest(new { status = msg });
            }

        }

        [HttpPost]
        [Route("userprofile/delete")]
        public async Task<IActionResult> Userprofiledelete(Userprofile acc)
        {

            string msg = new UserprofileService().DeleteUserprofile(acc, conn);

            if (msg == "Deleted User Profile Successfully")
            {
                return Ok(new { status = msg });
            }
            else if (msg == "Deletion Failed, User Account Doesn't Exist")
            {
                return BadRequest(new { status = msg });
            }
            else
            {
                return BadRequest(new { status = msg });
            }


        }


        [HttpPost]
        [Route("userprofile/orderhistory")]
        public async Task<IActionResult> Userorderhistory(Orderhistory acc)
        {

            string data = new OrderhistoryService().orderhistory(acc, conn);

            if (data == "No previous orders")
            {
                return BadRequest(new { status = data });
            }
            else if (data.Contains('{') == true)
            {
                return Ok(new { status = data });
            }
            else
            {
                return BadRequest(new { status = data });
            }


        }

        [HttpPost]
        [Route("/booking")]
        public async Task<IActionResult> Booking(Booking acc)
        {

            string data = new BookingService().Book(acc, conn);

            if (data == "Booking Success")
            {
                return Ok(new { status = data });
            }
            else if (data == "Booking Error")
            {
                return BadRequest(new { status = data });
            }
            else
            {
                return BadRequest(new { status = data });
            }

        }

        [HttpPost]
        [Route("bookings/delete")]
        public async Task<IActionResult> DeleteBooking(DeleteBooking acc)
        {

            string msg = new DeleteBookingService().Delete(acc, conn);

            if (msg == "Delete Booking Success")
            {
                return Ok(new { status = msg });
            }
            else if (msg == "Delete Booking Error")
            {
                return BadRequest(new { status = msg });
            }
            else
            {
                return BadRequest(new { status = msg });
            }

        }

        [HttpGet]
        [Route("/employeelist")]
        public async Task<IActionResult> Employeelist(Employeelisting acc)
        {

            string data = new EmployeelistingService().Employee_list(acc, conn);

            if (data == "All Employees are busy. Please Choose different time slot")
            {
                return BadRequest(new { status = data });
            }
            else if (data.Contains('{') == true)
            {
                return Ok(new { status = data });
            }
            else
            {
                return BadRequest(new { status = data });
            }

        }



        ~MainController()
        {
            conn.Close();
        }

    }
}