using ServiceGo.Models;
using System.Data;
using System.Data.SqlClient;

namespace ServiceGo.Services
{
    public class EmployeelistingService
    {

        public string Employee_list(Employeelisting acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("select Employees.name,Employees.email,Employees.rating,Employees.phone,Employees.cost from Employees where category = '"+acc.category+ "' and id not in (select emp_id from Orders where date = '"+acc.date+ "' and time_slot= '"+acc.timeslot+"')", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                string JSONString = string.Empty;

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
                    JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(objects);
                    return JSONString;
                }
                else
                {
                    msg = "All Employees are busy. Please Choose different time slot";
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
