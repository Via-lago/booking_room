using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_room.Model;
using booking_room.Context;

namespace booking_room.Controller
{
    public class EducationController
    {

        // GET : Universities
        public List<Education> GetEducation()
        {
            var Education = new List<Education>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Education();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);

                        Education.Add(education);
                    }

                    return Education;
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
            return new List<Education>();
        }

        // INSERT : Universities

        public int InsertEducations(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations(major,degree,gpa,university_id) VALUES (@major,@degree,@gpa,@university_id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 50;
                pMajor.Value = education.Major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 50;
                pDegree.Value = education.Degree;

                var pGPA = new SqlParameter();
                pGPA.ParameterName = "@gpa";
                pGPA.SqlDbType = SqlDbType.VarChar;
                pGPA.Size = 50;
                pGPA.Value = education.GPA;

                var pUnivId = new SqlParameter();
                pUnivId.ParameterName = "@university_id";
                pUnivId.SqlDbType = SqlDbType.VarChar;
                pUnivId.Size = 50;
                pUnivId.Value = education.UniversityId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGPA);
                command.Parameters.Add(pUnivId);


                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
        // GET : Universities(5)

        public void GetEducationsById(Education education)
        {

            using var connection = MyConnection.Get();

            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * from tb_m_educations where id=@id";


                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                connection.Open();

                // Menjalankan command
                /* result = command.ExecuteNonQuery();*/

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id = " + reader.GetInt32(0));
                        Console.WriteLine("Major = " + reader.GetString(1));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // UPDATE : Universities(obj)

        public  int UpdateEducations(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update tb_m_educations set major=@major where id =@id  ";
                command.Transaction = transaction;

                // Membuat parameter
                var pUpdate = new SqlParameter();
                pUpdate.ParameterName = "@major";
                pUpdate.SqlDbType = SqlDbType.VarChar;
                pUpdate.Size = 50;
                pUpdate.Value = education.Major;

                var pUpdate2 = new SqlParameter();
                pUpdate2.ParameterName = "@id";
                pUpdate2.SqlDbType = SqlDbType.VarChar;
                pUpdate2.Size = 50;
                pUpdate2.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pUpdate);
                command.Parameters.Add(pUpdate2);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();

            }
            finally
            {
                connection.Close();
            }

            return result;
        }
        // DELETE : Universities(5)

        public int DeleteEducationById(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
