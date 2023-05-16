using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Context
{
    public class MyConnection
    {
        private static readonly string connectionString =

        "Data Source=LAPTOP-N3R9H5VB\\MSSQLSERVER02;database= db_booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection Get()
        {
            /*var connection = new SqlConnection(connectionString);
            try {
                connection.Open();
                Console.WriteLine("Connection Open!");
            }
            catch (Exception e){
                Console.WriteLine("Error in connection" + e.Message);
            }
            finally {
                connection.Close();
            }
            return connection;*/

            return new SqlConnection(connectionString);
        }
    }
}
