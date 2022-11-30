using System.Data.SqlClient;
using ServiceGo.Models;
using System.Data;

namespace ServiceGo.Services
{
    public class DeleteBookingService
    {
        public string Delete(DeleteBooking acc, SqlConnection conn)
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

            return msg;

        }

    }
}
