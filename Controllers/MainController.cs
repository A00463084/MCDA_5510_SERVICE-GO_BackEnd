using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;
using ServiceGo.Services;
using Stripe;
using Microsoft.Extensions.Options;

namespace ServiceGo.Controllers
{
    public class StripeOptions
    {
        public string option { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        public readonly IOptions<StripeOptions> options;
        public readonly IStripeClient client;

        public readonly IConfiguration _configuration;
        SqlConnection conn;

        public MainController(IConfiguration configuration, IOptions<StripeOptions> options)
        {
            _configuration = configuration;

            this.options = options;
            this.client = new StripeClient("sk_test_51MDemNKaNeuM0GXPMIA7qOxbQay2HlEx3MUsiBqthRxH3ksJCcy6tCmlvRGjodyScazsPBDRcL20UKU30Ee43Aub005zihGai3");

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

        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent(Payment acc)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = acc.amount,
                Currency = "CAD",
            };
            var service = new PaymentIntentService(this.client);
            
            try
            {
                var paymentIntent = await service.CreateAsync(options);
                return Ok(new { clientSecret = paymentIntent.ClientSecret });
            } 
            catch(Stripe.StripeException ex)
            {
                return BadRequest(new
                {
                    Error = new { 
                        Message = ex.Message
                    }
                });
            }
        }



        ~MainController()
        {
            conn.Close();
        }

    }
}