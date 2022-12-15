using Microsoft.AspNetCore.Mvc;
using ServiceGo.Models;
using System.Data;
using System.Data.SqlClient;

namespace ServiceGo.Services
{
    public class EmployeelistingService : Controller
    {

        public ActionResult Employee_list(Employeelisting acc, SqlConnection conn)
        {
            string msg = string.Empty;
            string JSONString = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT Employees.id,Employees.name,Employees.email,Employees.rating,Employees.phone,Employees.cost FROM EMPLOYEES WHERE category = '"+acc.category+ "' and id not in (SELECT emp_id FROM ORDERS where date = '"+acc.date+ "' and time_slot= '"+acc.timeslot+"')", conn);

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
                    
                    msg = "All Employees are busy. Please Choose different time slot";
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
