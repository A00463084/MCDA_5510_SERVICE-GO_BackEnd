using ServiceGo.Models;
using System.Data;
using System.Data.SqlClient;

namespace ServiceGo.Services
{
    public class OrderhistoryService
    {
        public string orderhistory(Orderhistory acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("Select distinct Orders.date, Orders.time_slot, Employees.name, Employees.category, Employees.Cost from Orders, Employees, Users where Orders.emp_id=Employees.id and Orders.user_id = (select id from Users where email = '" + acc.email + "') order by Orders.date desc",conn);

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
                    msg = "No previous orders";
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
