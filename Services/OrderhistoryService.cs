using ServiceGo.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGo.Services
{
    public class OrderhistoryService: Controller
    {
        public ActionResult orderhistory(Orderhistory acc, SqlConnection conn)
        {
            string msg = string.Empty;
            string JSONString = string.Empty;

            try
            {

                SqlCommand cmd = new SqlCommand("Select distinct Orders.date, Orders.time_slot, Employees.name, Employees.category, Employees.Cost from Orders, Employees, Users where Orders.emp_id=Employees.id and Orders.user_id = (select id from Users where email = '" + acc.email + "') order by Orders.date desc",conn);

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
                        objects.Add(record);
                        
                        

                    }
                    return Json(objects);
                }
                else
                {

                    msg = "No previous orders";
                    IDictionary<string, object> r = new Dictionary<string, object>();
                    List<object> msg_obj = new List<object>();
                    r.Add("Status", msg);
                    msg_obj.Add(r);
                    return Json(msg_obj);
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                IDictionary<string, object> r = new Dictionary<string, object>();
                List<object> msg_obj = new List<object>();
                r.Add("Status", msg);
                msg_obj.Add(r);
                return Json(msg_obj);
            }

            
        }

    }
}
