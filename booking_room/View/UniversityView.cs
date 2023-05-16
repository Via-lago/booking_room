using booking_room.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.View
{
    public class UniversityView
    {
        public static void Output(Universities university)
        {
            Console.WriteLine("");
            Console.WriteLine("Id: " + university.Id);
            Console.WriteLine("Name: " + university.Name);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Universities> universities)
        {
            foreach (var university in universities)
            {
                Output(university);
            }
        }
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

    }
}
