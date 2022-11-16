using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ServiceGo.Models;

namespace ServiceGo.Controllers
{
    public class UserprofileController : Controller
    {
        public string UpdateUserprofile(Userprofile acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("Update Users set name = '"+acc.name+"', password = '"+acc.password+"', address = '"+acc.address + "', city = '"+acc.city + "', province = '"+acc.province + "', country = '"+acc.country + "', postal_code = '"+acc.postal_code+"', phone = '"+acc.phone+"' where email = '"+acc.email+"'", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                    msg = "Update User Profile";
                }
                else
                {
                    msg = "Update Failed, User Account Doesn't Exist";
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;

        }

        public string DeleteUserprofile(Userprofile acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("Delete from  Users where email = '" + acc.email + "'", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                    msg = "Update User Profile";
                }
                else
                {
                    msg = "Update Failed, User Account Doesn't Exist";
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
