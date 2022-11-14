using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ServiceGo.Models;


namespace ServiceGo.Controllers
{
    public class SignupController : Controller
    {
        public string Signup(Signup acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                
                SqlCommand cmd = new SqlCommand("Insert into Users (name,password,email,address,city,province,country,postal_code,phone) values ('" + acc.name + "','" + acc.password + "','" + acc.email + "','" + acc.address + "','" + acc.city + "','" + acc.province + "','" + acc.country + "','" + acc.postal_code + "','" + acc.phone + "')",conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                    msg = "Data Inserted";
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
