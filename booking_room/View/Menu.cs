using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using booking_room.Controller;

namespace booking_room.View
{
    public class Menu
    {

        public static void daftarmenu()
        {
            var university = new Model.Universities();
            var educations = new Model.Education();
            int pilih;
            int input;
            int pilihan;
            int idUniv;
            int idEduc;
            string namauniv;
            int updateid;
            string updatename;
            int idEdu;
            string nameEdu;
            string major;
            string degree;
            string gpa;
            int univ;
            int delIdUniv;
            int delIdEdu;

            Console.WriteLine("================ Menu  ================");
            Console.WriteLine("1.Data University ");
            Console.WriteLine("2.Data Education");
            Console.WriteLine("3.Insert Data");
            Console.WriteLine("4.Data Employee");
            Console.WriteLine("5.Data Profilings");
            Console.WriteLine("6.Semua Data");
            Console.WriteLine("7. Exit");
            Console.WriteLine("================");

            Console.WriteLine("Pilihan: ");
            pilih = Convert.ToInt16(Console.ReadLine());
            
            // Variable baru untuk class
            var c = new CRUD();
            var ce = new CrudEdu();
            
            if (pilih == 1 || pilih == 2)
            {
                Console.WriteLine("================ Pilih Aksi Yang Akan Dilakukan ================");
                Console.WriteLine("1.Tampilkan Semua Data");
                Console.WriteLine("2.Tampilkan Data berdasarkan Id");
                Console.WriteLine("3.Insert Data");
                Console.WriteLine("4.Update Data");
                Console.WriteLine("5.Delete Data");
                Console.WriteLine("================");
            }

               switch (pilih)
            {
                case 1:
                    Console.WriteLine("Pilih aksi: ");
                    pilihan = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("================");

                    if (pilihan == 1)
                    {
                        
                        var results = c.GetUniversities();
                        Console.WriteLine("Data University (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        foreach (var result in results)
                        {
                            Console.WriteLine("Id: " + result.Id);
                            Console.WriteLine("Name: " + result.Name);
                        }
                    }
                    if (pilihan == 2)
                    {
                        Console.WriteLine("Masukan Id : ");
                        idUniv = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("====================");
                        Console.WriteLine("UniversitiesByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Id = idUniv;
                        c.GetUniversityById(university);
                    }
                    if (pilihan == 3)
                    {
                        Console.WriteLine("Masukan Nama : ");
                        namauniv = Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("Insert Data Education (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Name = namauniv;
                        var result = c.InsertUniversity(university);
                        Console.WriteLine("====================");
                        if (result > 0)
                        {
                            Console.WriteLine("Insert success.");
                        }
                        else
                        {
                            Console.WriteLine("Insert failed.");
                        }
                    }
                    if (pilihan == 4)
                    {
                        
                        Console.WriteLine("Masukan Id : ");
                        updateid = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Masukan Nama : ");
                        updatename = Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("UpdateData (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Id = updateid;
                        university.Name = updatename;
                        var result = c.UpdateUniversity(university);
                     
                    }
                    else if (pilihan == 5)
                    {
                        
                        Console.WriteLine("Masukan Id : ");
                        delIdUniv = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("====================");
                        Console.WriteLine("DeleteByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Id = delIdUniv;
                        var result = c.DeleteUniversityById(university);
                        
                    }

                    break;

                case 2:
                    Console.WriteLine("Pilih aksi: ");
                    pilihan = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("================");

                    if (pilihan == 1)
                    {
                        var results = ce.GetEducation();
                        Console.WriteLine("Data Education (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        foreach (var result in results)
                        {
                            Console.WriteLine("Id: " + result.Id);
                            Console.WriteLine("Major: " + result.Major);
                            Console.WriteLine("Degree: " + result.Degree);
                            Console.WriteLine("GPA: " + result.GPA);
                        }
                    }

                    if (pilihan == 2)
                    {
                        Console.WriteLine("Masukan Id : ");
                        Console.WriteLine("====================");
                        idEduc = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("EducationsByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id = idEduc;
                        ce.GetEducationsById(educations);
                    }
                    if (pilihan == 3)
                    {
                        Console.WriteLine("Masukan Major : ");
                        major = Console.ReadLine();
                        Console.WriteLine("Masukan Degree : ");
                        degree = Console.ReadLine();
                        Console.WriteLine("Masukan GPA: ");
                        gpa = Console.ReadLine();
                        Console.WriteLine("Masukan University ID : ");
                        univ = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Insert Data Educations(OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Major = major;
                        educations.Degree = degree;
                        educations.GPA = gpa;
                        educations.UniversityId = univ;
                        var result = ce.InsertEducations(educations);
                        Console.WriteLine("Insert success.");
                        
                    }
                    if (pilihan == 4)
                    {
                        Console.WriteLine("Masukan Id : ");
                        idEdu = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Masukan Major: ");
                        nameEdu = Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("UpdateDataEducations (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id = idEdu;
                        educations.Major = nameEdu;
                        var result = ce.UpdateEducations(educations);
                        Console.WriteLine("Update success.");
                        
                    }
                    else if (pilihan == 5)
                    {
                        Console.WriteLine("Masukan Id : ");
                        delIdEdu = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("====================");
                        Console.WriteLine("DeleteByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id = delIdEdu;
                        var result = ce.DeleteEducationById(educations);
                        Console.WriteLine("Delete success.");
                    }
                    break;

                case 3:
                    var i = new InsertData();
                    i.Inputan();
                break;

                case 4:
                    var em = new DataEmployee();
                    var results1 = em.GetEmployee();
                    Console.WriteLine("Data Employee (OKTAVIA DEYO LAGO)");
                    Console.WriteLine("====================");
                    foreach (var result1 in results1)
                    {
                        Console.WriteLine("Id: " + result1.Id);
                        Console.WriteLine("NIK: " + result1.NIK);
                        Console.WriteLine("First Name: " + result1.FirstName);
                        Console.WriteLine("Last Name: " + result1.LastName);
                        Console.WriteLine("Birthdate : " + result1.Birthdate);
                        Console.WriteLine("Gender : " + result1.Gender);
                        Console.WriteLine("HiringDate : " + result1.HiringDate);
                        Console.WriteLine("Email : " + result1.Email);
                        Console.WriteLine("PhoneNumber : " + result1.PhoneNumber);
                        Console.WriteLine("DepartmenId : " + result1.DepartmentId);
                    }
                    /*Console.WriteLine("=================================");
                    var getEmployee = from e in Employee.GetEmployee()
                                      where e.Gender == "Male"
                                      select e; 
                    foreach(var Item in getEmployee)
                    {
                        Console.WriteLine(Item.Gender);
                    }*/
                    break;

                case 5:
                    var p =new ProfillingsCont();  
                    var results2 = p.GetProfilings();
                    foreach (var result2 in results2)
                    {
                        Console.WriteLine("Employee id : " + result2.EmployeeId);
                        Console.WriteLine("Education id : " + result2.EducationId);
                    }
                    break;

                case 6:
                    var t =new TampilanLINQ(); 
                    t.PrintOutData();
                    break;

            }
        }
    }
}
