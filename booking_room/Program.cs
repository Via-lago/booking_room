using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using System.Data.Common;
using booking_room.View;
using booking_room.Context;
using System.Security.Cryptography.X509Certificates;
using booking_room.Controller;
using System.Xml.Schema;
using booking_room.Model;

public class Program
{

    public static void Main()
    {
        menu();
    }

    public static void menu()
    {
        Console.WriteLine("================ Menu  ================");
        Console.WriteLine("1.Select ");
        Console.WriteLine("2.Insert");
        Console.WriteLine("3.Update");
        Console.WriteLine("4.Delete");
        Console.WriteLine("5.Insert All Data");
        Console.WriteLine("6.Join Table LINQ");
        Console.WriteLine("7. Exit");
        Console.WriteLine("================");

        Console.WriteLine("Pilihan: ");
        int pilih = Convert.ToInt16(Console.ReadLine());


        switch (pilih)
        {
            case 1:
                var s = new MenuView();
                s.Pilihtabel();
                Console.Write("Pilih tabel : ");
                int pilihanG = Convert.ToInt16(Console.ReadLine());
                SelectTable(pilihanG);
                break;

            case 2:
                var i = new MenuView();
                i.Pilihtabel();
                Console.Write("Pilih tabel : ");
                int pilihanI = Convert.ToInt16(Console.ReadLine());
                InsertTable(pilihanI);
                break;

            case 3:
                var u = new MenuView();
                u.Pilihtabel();
                Console.Write("Pilih tabel : ");
                int pilihanU = Convert.ToInt16(Console.ReadLine());
                UpdateTable(pilihanU);
                break;

            case 4:
                var d = new MenuView();
                d.Pilihtabel();
                Console.Write("Pilih tabel : ");
                int pilihanD = Convert.ToInt16(Console.ReadLine());
                InsertTable(pilihanD);
                break;

            case 5:
                InsertAll();
            break;
            case 6:
                join();
            break;
            case 7:

                break;
        }
    }
    public static void SelectTable(int pilihan)
    {
        switch (pilihan)
        {
            case 1:
                UniversityController.Get();
                break;

            case 2:
                EducationController.Get();
                break;

        }

    }

    public static void InsertTable(int pilihan)
    {
        switch (pilihan)
        {
            case 1:
                UniversityController.Insert();
                break;

            case 2:
                EducationController.Insert();
                break;

        }
    }

    public static void DeleteTable(int pilihan)
    {
        switch (pilihan)
        {
            case 1:
                UniversityController.Delete();
              
                break;

            case 2:
                EducationController.Delete();
                break;
        }
    }

    public static void UpdateTable(int pilihan)
    {
        switch (pilihan)
        {
            case 1:
               UniversityController.Update();
                break;
            case 2:
                EducationController.Update();
                break;
        }
    }

    public static void InsertAll()
    {
        var All = new Employee();
        All.Inputan();
    }

    public static void join()
    { 
        PrintOutData();
    }

    public static void PrintOutData()
    {
        var DataEmployee = new Employee();
        var Profilling = new Profilings();
        var crudedu = new Education();
        var crud = new Universities();
        var getEmployee1 = DataEmployee.GetEmployee();
        var getProfilings = Profilling.GetProfilings();
        var educations1 = crudedu.GetEducation();
        var univ1 = crud.GetUniversities();

        var i = from e in getEmployee1
                join p in getProfilings
                on e.Id equals p.EmployeeId
                join ed in educations1 on p.EducationId equals ed.Id
                join u in univ1 on p.EducationId equals u.Id
                select new
                {
                    e.NIK,
                    Full_Name = e.FirstName + " " + e.LastName,
                    e.Birthdate,
                    e.Gender,
                    e.HiringDate,
                    e.Email,
                    e.PhoneNumber,
                    ed.Major,
                    ed.Degree,
                    ed.GPA,
                    UnivName = u.Name
                };
        foreach (var Item in i)
        {
            Console.WriteLine($"NIK  : {Item.NIK}");
            Console.WriteLine($"First Name : {Item.Full_Name}");
            Console.WriteLine($"Birthdate  : {Item.Birthdate}");
            Console.WriteLine($"Gender : {Item.Gender}");
            Console.WriteLine($"Hiring Date :{Item.HiringDate}");
            Console.WriteLine($"Email  : {Item.Email}");
            Console.WriteLine($"PhoneNumber : {Item.PhoneNumber}");
            Console.WriteLine($"Major  : {Item.Major}");
            Console.WriteLine($"Degree : {Item.Degree}");
            Console.WriteLine($"GPA :  {Item.GPA}");
            Console.WriteLine($"UnivName :  {Item.UnivName}");
        }
    }
}

