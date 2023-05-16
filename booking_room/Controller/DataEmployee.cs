using booking_room.Context;
using booking_room.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Controller
{
    public class DataEmployee
    {
        public List<Employee> GetEmployee()
        {
            var Employee = new List<Employee>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employee";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader[0].ToString();
                        employee.NIK = reader.GetString(1);
                        employee.FirstName = reader.GetString(2);
                        employee.LastName = reader.GetString(3);
                        employee.Birthdate = reader.GetDateTime(4);
                        employee.Gender = reader.GetString(5);
                        employee.HiringDate = reader.GetDateTime(6);
                        employee.Email = reader.GetString(7);
                        employee.PhoneNumber = reader.GetString(8);
                        employee.DepartmentId = reader.GetString(9);


                        Employee.Add(employee);
                    }

                    return Employee;
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
            return new List<Employee>();
        }
    }
}
