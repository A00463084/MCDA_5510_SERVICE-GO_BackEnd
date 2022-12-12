using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;
using System.Net;

namespace ServiceGo.Services
{
    public class LoginService : Controller
    {
        public ActionResult Login(Login acc, SqlConnection conn) 
        {
            string msg = string.Empty;
            
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email='" + acc.email + "' AND password='" + acc.password + "'", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    msg = "User Login Successful";
                    
                }
                else
                {
                    
                    msg = "Login Error";
                    
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            IDictionary<string, object> r = new Dictionary<string, object>();
            List<object> msg_obj = new List<object>();
            r.Add("Status", msg);
            msg_obj.Add(r);
            return Json(msg_obj);



        }

    }
}
