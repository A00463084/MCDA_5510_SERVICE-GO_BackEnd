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

                SqlCommand cmd = new SqlCommand("SELECT id, name FROM Users WHERE email='" + acc.email + "' AND password='" + acc.password + "'", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                List<object> objects = new List<object>();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDictionary<string, object> record = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            record.Add(reader.GetName(i), reader[i]);

                        }
                        msg = "User Login Successful";
                        record.Add("Status", msg);
                        objects.Add(record);



                    }
                    return Json(objects);
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
