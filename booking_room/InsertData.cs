using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room
{
    public class InsertData
    {
        private static readonly string connectionString =

       "Data Source=LAPTOP-N3R9H5VB\\MSSQLSERVER02;database= db_booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        
        public static int InsertEmployee(Employee employee)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_employee (nik,first_name,last_name,birthdate,gender,hiring_date,email,phone_number,department_id) " +
                    "VALUES (@nik,@first_name,@last_name,@birthdate,@gender,@hiring_date,@email,@phone_number,@department_id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pNIK = new SqlParameter();
                pNIK.ParameterName = "@nik";
                pNIK.SqlDbType = SqlDbType.VarChar;
                pNIK.Size = 50;
                pNIK.Value = employee.NIK;

                var pFirstName = new SqlParameter();
                pFirstName.ParameterName = "@first_name";
                pFirstName.SqlDbType = SqlDbType.VarChar;
                pFirstName.Size = 50;
                pFirstName.Value = employee.FirstName;

                var pLastName = new SqlParameter();
                pLastName.ParameterName = "@last_name";
                pLastName.SqlDbType = SqlDbType.VarChar;
                pLastName.Size = 50;
                pLastName.Value = employee.LastName;

                var pBirthdate = new SqlParameter();
                pBirthdate.ParameterName = "@birthdate";
                pBirthdate.SqlDbType = SqlDbType.DateTime;
                pBirthdate.Value = employee.Birthdate;

                var pGender = new SqlParameter();
                pGender.ParameterName = "@gender";
                pGender.SqlDbType = SqlDbType.VarChar;
                pGender.Size = 50;
                pGender.Value = employee.Gender;

                var pHiring = new SqlParameter();
                pHiring.ParameterName = "@hiring_date";
                pHiring.SqlDbType = SqlDbType.DateTime;
                pHiring.Value = employee.HiringDate;

                var pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Size = 50;
                pEmail.Value = employee.Email;

                var pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone_number";
                pPhone.SqlDbType = SqlDbType.VarChar;
                pPhone.Size = 50;
                pPhone.Value = employee.PhoneNumber;

                var pDeptId = new SqlParameter();
                pDeptId.ParameterName = "@department_id";
                pDeptId.SqlDbType = SqlDbType.Int;
                pDeptId.Size = 50;
                pDeptId.Value = employee.DepartmentId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pNIK);
                command.Parameters.Add(pFirstName);
                command.Parameters.Add(pLastName);
                command.Parameters.Add(pBirthdate);
                command.Parameters.Add(pGender);
                command.Parameters.Add(pHiring);
                command.Parameters.Add(pEmail);
                command.Parameters.Add(pPhone);
                command.Parameters.Add(pDeptId);

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

        public static int InsertEducations(Education education)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations(major,degree,gpa) " +
                    "VALUES (@major,@degree,@gpa) ";
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

                /*var pUnivId = new SqlParameter();
                pUnivId.ParameterName = "@university_id";
                pUnivId.SqlDbType = SqlDbType.VarChar;
                pUnivId.Size = 50;
                pUnivId.Value = education.UniversityId;*/

                // Menambahkan parameter ke command
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGPA);
                /*command.Parameters.Add(pUnivId);*/


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

        public static int GetEducationsById(Education education)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);


            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select top 1 id from tb_m_educations order by id desc;";



                // Menambahkan parameter ke command
                
                connection.Open();

                // Menjalankan command
                int LastInsertId = Convert.ToInt32(command.ExecuteScalar());

                /*using SqlDataReader reader = command.ExecuteReader();*/
                return LastInsertId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static int InsertUniversity(Universities university)
        {
            int result1 = 0;
            using var connection = new SqlConnection(connectionString);
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
                result1 = command.ExecuteNonQuery();
                transaction.Commit();

                return result1;
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

            return result1;
        }

        public static string GetProfilingsById(String NIK)
        {
            string result= "";
            using var connection = new SqlConnection(connectionString);


            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select id from tb_m_employee where nik = @nik;";

                // Menambahkan parameter ke command

                connection.Open();
                var pNIK = new SqlParameter();
                pNIK.ParameterName = "@nik";
                pNIK.SqlDbType = SqlDbType.VarChar;
                pNIK.Size = 50;
                pNIK.Value = NIK;
                command.Parameters.Add(pNIK);

                // Menjalankan command
                String LastInsertId = Convert.ToString(command.ExecuteReader());

                return LastInsertId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int InsertProfilling(Profilings profilings)
        {
            int result1 = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings values (@employee_id,@education_id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pId1 = new SqlParameter();
                pId1.ParameterName = "@employee_id";
                pId1.SqlDbType = SqlDbType.UniqueIdentifier;
                pId1.Value = Guid.Parse(profilings.EmployeeId);

                var pId2 = new SqlParameter();
                pId2.ParameterName = "@education_id";
                pId2.SqlDbType = SqlDbType.Int;
                pId2.Size = 50;
                pId2.Value = profilings.EducationId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId1);
                command.Parameters.Add(pId2);

                // Menjalankan command
                result1 = command.ExecuteNonQuery();
                transaction.Commit();

                return result1;
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

            return result1;
        }

        public static void Inputan() 
        {
            var educations = new Education();
            var employee = new Employee();
            var university= new Universities();
            var profiling = new Profilings();
            string nik;
            string firstName;
            string lastName;
            string gender;
            string email;
            string phone;
            string major;
            string degree;
            int departmentId;
            string gpa;
            string univ;
            int EduId;
            string Employee;


            Console.WriteLine("==========Insert Data==========");
            Console.WriteLine("====================");
     /*       Console.WriteLine("NIK : ");
            nik = Console.ReadLine();
            Console.WriteLine("First Name : ");
            firstName = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            lastName = Console.ReadLine();
            Console.WriteLine("Birthdate (YYYY/MM/DD): ");
            var Birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Gender (Female/Male) : ");
            gender = Console.ReadLine();
            Console.WriteLine("Hiring Date (YYYY,MM,DD): ");
            var hiring = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Email : ");
            email = Console.ReadLine();
            Console.WriteLine("Phone Number : ");
            phone = Console.ReadLine();
            Console.WriteLine("Department ID :");
            departmentId = Convert.ToInt16(Console.ReadLine()); ;
            Console.WriteLine("Major : ");
            major = Console.ReadLine();
            Console.WriteLine("Degree : ");
            degree = Console.ReadLine();
            Console.WriteLine("GPA : ");
            gpa = Console.ReadLine();
            Console.WriteLine("University Name : ");
            univ = Console.ReadLine();*/

            nik = "981832";
            firstName = "Harr";
            lastName = "Tan";
            DateTime Birth = new DateTime(1987, 02, 05);
            gender = "Female";
            DateTime hiring = new DateTime(2021,04,05);
            email = "HRTN";
            phone = "90899.998128.16783";
            departmentId = 30;
            major = "Sistem Informasi";
            degree = "S1";
            gpa = "3.40";
            univ = "Universitas Bogor";

            Console.WriteLine("Insert Data Educations(OKTAVIA DEYO LAGO)");
            Console.WriteLine("====================");
            employee.NIK = nik;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Birthdate = Birth;
            employee.Gender = gender;
            employee.HiringDate = hiring;
            employee.Email  = email;
            employee.PhoneNumber = phone;
            employee.DepartmentId = departmentId;
            university.Name = univ;
            educations.Major = major;
            educations.Degree = degree;
            educations.GPA = gpa;

            profiling.EducationId = 0;
            profiling.EmployeeId ="";

            try
            {
                var result = InsertData.InsertEmployee(employee);
                var result1 = InsertData.InsertUniversity(university);
                var result2 = InsertData.InsertEducations(educations);
                var result3 = InsertData.GetProfilingsById(employee.NIK);
                Console.WriteLine(result3);
                var result4 = InsertData.GetEducationsById(educations);
                Console.WriteLine(result4);
                var result5 = InsertData.InsertProfilling(profiling);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
