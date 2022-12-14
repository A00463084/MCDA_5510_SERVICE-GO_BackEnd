using System.Data.SqlClient;
using ServiceGo.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGo.Services
{
    public class DeleteBookingService : Controller
    {
        public ActionResult Delete(DeleteBooking acc, SqlConnection conn)
        {
            string msg = string.Empty;
           
            try
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE id = '" + acc.id + "'", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                   
                    msg = "Delete Booking Success";
                    
                }
                else
                {
                    
                    msg = "Delete Booking Error";
                    

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
