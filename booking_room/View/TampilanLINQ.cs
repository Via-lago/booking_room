using booking_room.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.View
{
    public class TampilanLINQ
    {
        public void PrintOutData()
        {
            var DataEmployee = new DataEmployee();
            var ProfillingCont = new ProfillingsCont();
            var crudedu = new CrudEdu();
            var crud = new CRUD();
            var getEmployee1 = DataEmployee.GetEmployee();
            var getProfilings = ProfillingCont.GetProfilings();
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
}
