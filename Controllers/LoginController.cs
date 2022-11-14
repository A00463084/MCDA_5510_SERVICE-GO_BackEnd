using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;


namespace ServiceGo.Controllers
{
    public class LoginController : Controller
    {
        public string Login (Login acc, SqlConnection conn)
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
