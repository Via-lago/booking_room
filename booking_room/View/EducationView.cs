using booking_room.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.View
{
    public class EducationView
    {
        public static void Output(Education education)
        {
            Console.WriteLine("Id: " + education.Id);
            Console.WriteLine("Major: " + education.Major);
            Console.WriteLine("Degree: " + education.Degree);
            Console.WriteLine("GPA: " + education.GPA);
            Console.WriteLine("University ID: " + education.UniversityId);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Education> educations)
        {
            foreach (var education in educations)
            {
                Output(education);
            }
        }
        public void Output(string message)
        {
            Console.WriteLine(message);
        }


    }
}
