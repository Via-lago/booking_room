using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room
{
   public class Menu
    {

        public static void daftarmenu()
        {
            var university = new Universities();
            var educations = new Education();
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
            Console.WriteLine("4. Exit");
            Console.WriteLine("================");

            Console.WriteLine("Pilihan: ");
            pilih = Convert.ToInt16(Console.ReadLine());

            if(pilih == 1 || pilih == 2)
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
                        var results = CRUD.GetUniversities();
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
                        CRUD.GetUniversityById(university);
                    }
                    if(pilihan == 3)
                    {
                        Console.WriteLine("Masukan Nama : ");
                        namauniv=Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("Insert Data Education (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Name = namauniv;
                        var result = CRUD.InsertUniversity(university);
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
                        updateid= Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Masukan Nama : ");
                        updatename= Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("UpdateData (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Id = updateid;
                        university.Name = updatename;
                        var result = CRUD.UpdateUniversity(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Update success.");
                        }
                        else
                        {
                            Console.WriteLine("Update failed.");
                        }
                    }
                    else if (pilihan == 5) 
                    {
                        Console.WriteLine("Masukan Id : ");
                        delIdUniv = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("====================");
                        Console.WriteLine("DeleteByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        university.Id = delIdUniv;
                        var result = CRUD.DeleteUniversityById(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete success.");
                        }
                        else
                        {
                            Console.WriteLine("Delete failed.");
                        }
                    }
                    
                break;

                case 2:
                    Console.WriteLine("Pilih aksi: ");
                    pilihan = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("================");
                    
                    if (pilihan == 1)
                    {
                        var results = CrudEdu.GetEducation();
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

                    if(pilihan == 2)
                    {
                        Console.WriteLine("Masukan Id : ");
                        Console.WriteLine("====================");
                        idEduc = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("EducationsByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id =idEduc;
                        CrudEdu.GetEducationsById(educations);
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
                        var result = CrudEdu.InsertEducations(educations);
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
                        idEdu = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Masukan Major: ");
                        nameEdu = Console.ReadLine();
                        Console.WriteLine("====================");
                        Console.WriteLine("UpdateDataEducations (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id = idEdu;
                        educations.Major = nameEdu;
                        var result = CrudEdu.UpdateEducations(educations);
                        if (result > 0)
                        {
                            Console.WriteLine("Update success.");
                        }
                        else
                        {
                            Console.WriteLine("Update failed.");
                        }
                    }
                    else if (pilihan == 5) 
                    {
                        Console.WriteLine("Masukan Id : ");
                        delIdEdu = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("====================");
                        Console.WriteLine("DeleteByID (OKTAVIA DEYO LAGO)");
                        Console.WriteLine("====================");
                        educations.Id = delIdEdu;
                        var result = CrudEdu.DeleteEducationById(educations);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete success.");
                        }
                        else
                        {
                            Console.WriteLine("Delete failed.");
                        }
                    }
                    break;

                case 3:

                    
                    InsertData.Inputan();

                break;

            }
          
            }

        }
    }
