using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_room.Context;
using booking_room.Model;

namespace booking_room.Controller
{
    public class CRUD

    {

        // GET : Universities 
        public List<Universities> GetUniversities()
        {
            using var connection = MyConnection.Get();
            var universities = new List<Universities>();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university = new Universities();
                        university.Id = reader.GetInt32(0);
                        university.Name = reader.GetString(1);

                        universities.Add(university);
                    }

                    return universities;
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
            return new List<Universities>();
        }

        // INSERT : Universities

        public int InsertUniversity(Universities university)
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
                command.CommandText = "INSERT INTO tb_m_universities(nama) VALUES (@name)";
                command.Transaction = transaction;

                // Membuat parameter
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 50;
                pName.Value = university.Name;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

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

        public void GetUniversityById(Universities university)
        {
            int result = 0;
            using var connection = MyConnection.Get();

            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * from tb_m_universities where id=@id";


                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = university.Id;

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
                        Console.WriteLine("Nama = " + reader.GetString(1));
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

        public int UpdateUniversity(Universities university)
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
                command.CommandText = "update tb_m_universities set nama=@name where id =@id  ";
                command.Transaction = transaction;

                // Membuat parameter
                var pUpdate = new SqlParameter();
                pUpdate.ParameterName = "@name";
                pUpdate.SqlDbType = SqlDbType.VarChar;
                pUpdate.Size = 50;
                pUpdate.Value = university.Name;

                var pUpdate2 = new SqlParameter();
                pUpdate2.ParameterName = "@id";
                pUpdate2.SqlDbType = SqlDbType.VarChar;
                pUpdate2.Size = 50;
                pUpdate2.Value = university.Id;

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

        public int DeleteUniversityById(Universities university)
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
                command.CommandText = "DELETE FROM tb_m_universities WHERE id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = university.Id;

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
