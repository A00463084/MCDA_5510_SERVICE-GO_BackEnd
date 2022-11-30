using ServiceGo.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace ServiceGo.Services
{
    public class UserprofileService
    {
        public string UpdateUserprofile(Userprofile acc, SqlConnection conn)
        {
            string msg = string.Empty;
            

            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE USERS SET name = '" + acc.name + "', password = '" + acc.password + "', address = '" + acc.address + "', city = '" + acc.city + "', province = '" + acc.province + "', country = '" + acc.country + "', postal_code = '" + acc.postal_code + "', phone = '" + acc.phone + "' where email = '" + acc.email + "'", conn);

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

                SqlCommand cmd = new SqlCommand("DELETE FROM  Users WHERE email = '" + acc.email + "'", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                    
                    msg = "Deleted User Profile Successfully";
                    
                }
                else
                {
                    
                    msg = "Deletion Failed, User Account Doesn't Exist";
                    
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
