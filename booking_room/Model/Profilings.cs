using booking_room.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Model
{
    public class Profilings
    {
   
        public string EmployeeId { get; set; }
        public int EducationId { get; set; }

        public List<Profilings> GetProfilings()
        {
            var Profiling = new List<Profilings>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profilings";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var profilings = new Profilings();
                        profilings.EmployeeId = reader.GetGuid(0).ToString();
                        profilings.EducationId = reader.GetInt32(1);

                        Profiling.Add(profilings);
                    }

                    return Profiling;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Profilings>();
        }

    }
}
