using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_room.Model;
using booking_room.Context;
using booking_room.View;

namespace booking_room.Controller
{
    public class EducationController
    {
        public static void Get()
        {
            var e = new Education();
            var result = e.GetEducation();
            var view = new EducationView();
            if (result.Count == 0)
            {
                view.Output("Data tidak ditemukan");
            }
            else
            {
                view.Output(result);
            }
        }

        public static void Insert()
        {
            var education = new Education();
            var edu = new Education();
            Console.Write("Major: ");
            education.Major = Console.ReadLine();
            Console.Write("Degree: ");
            education.Degree = Console.ReadLine();
            Console.Write("GPA: ");
            education.GPA = Console.ReadLine();
            Console.Write("University ID: ");
            education.UniversityId = Convert.ToInt32(Console.ReadLine());
            
            var result = edu.InsertEducations(education);
            var view = new EducationView();
            if (result > 0)
            {
                view.Output("Insert success.");
            }
            else
            {
                view.Output("Insert Failed");
            }
        }

        public static void Update()
        {
            string input = Console.ReadLine();
            List<string> eColumnsToUpdate = new List<string>();
            if (input.Contains("1"))
            {
                eColumnsToUpdate.Add("major");
            }
            if (input.Contains("2"))
            {
                eColumnsToUpdate.Add("degree");
            }
            if (input.Contains("3"))
            {
                eColumnsToUpdate.Add("gpa");
            }
            if (input.Contains("4"))
            {
                eColumnsToUpdate.Add("university_id");
            }

            Dictionary<string, object> eUpdateColumns = new Dictionary<string, object>();
            foreach (string column in eColumnsToUpdate)
            {
                Console.Write($"Enter new {column}: ");
                string newValue = Console.ReadLine();
                eUpdateColumns.Add(column, newValue);
            }

            Console.Write("Insert column name as primary key: ");
            string ePrimaryKeyName = Console.ReadLine();

            Console.Write("Insert value of primary key: ");
            object ePrimaryKeyValue = Console.ReadLine();
            var education = new Education();
            var edu = new Education();
            var result = edu.UpdateEducations(education);
            var view = new EducationView();
            if (result > 0)
            {
                view.Output("Update Success.");
            }
            else
            {
                view.Output("Update Success");
            }
        }

        public static void Delete()
        {
            var education = new Education();
            Console.Write("Insert number of row: ");
            education.Id = Convert.ToInt32(Console.ReadLine());
            var edu =new Education();
            var result = edu.DeleteEducationById(education);
            var view = new EducationView();
            if (result > 0)
            {
                view.Output("Delete success.");
            }
            else
            {
                view.Output("Delete Failed");
            }


        }

    }
}
