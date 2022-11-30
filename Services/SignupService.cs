using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ServiceGo.Models;
using System.Data;
using Microsoft.AspNetCore.Routing;
using System.Net.Http;
using System.Net;


namespace ServiceGo.Services
{
    public class SignupService
    {
        public string Signup(Signup acc, SqlConnection conn)
        {
            string msg = string.Empty;
            
            try
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Users (name,password,email,address,city,province,country,postal_code,phone) VALUES ('" + acc.name + "','" + acc.password + "','" + acc.email + "','" + acc.address + "','" + acc.city + "','" + acc.province + "','" + acc.country + "','" + acc.postal_code + "','" + acc.phone + "')", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {

                    msg = "User Signup Successful";
                    
                }
                else
                {
                    msg = "Signup Error";
                    
                    
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
