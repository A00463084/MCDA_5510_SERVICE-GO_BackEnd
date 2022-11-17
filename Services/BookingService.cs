using System.Data.SqlClient;
using ServiceGo.Models;
using System.Data;

namespace ServiceGo.Services
{
    public class BookingService
    {
        public string Book(Booking acc, SqlConnection conn)
        {
            string msg = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Orders (date,time_slot,emp_id,user_id) VALUES ('" + acc.date + "','" + acc.time_slot + "','" + acc.emp_id + "','" + acc.user_id + "')", conn);

                cmd.CommandType = CommandType.Text;

                int k = cmd.ExecuteNonQuery();


                if (k > 0)
                {
                    msg = "Booking Success";
                }
                else
                {
                    msg = "Booking Error";
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
