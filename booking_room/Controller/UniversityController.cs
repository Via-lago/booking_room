using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_room.Context;
using booking_room.Model;
using booking_room.View;

namespace booking_room.Controller
{
    public class UniversityController

    {
        public static void Get()
        {
            var u = new Universities(); 
            var results = u.GetUniversities();
            var view = new UniversityView();
            if (results.Count == 0)
            {
                view.Output("Data tidak ditemukan");
            }
            else
            {
                view.Output(results);
            }

        }

        public static void Insert()
        {
            var u = new Universities();
            Console.Write("Name : ");
            u.Name = Console.ReadLine();
            var Un = new Universities();

            var result = Un.InsertUniversity(u);
            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Insert success.");
            }
            else
            {
                view.Output("Insert failed");
            }

        }

        public static void Update()
        {
            List<string> columnsToUpdate = new List<string>();
            columnsToUpdate.Add("name");

            Dictionary<string, object> updateColumns = new Dictionary<string, object>();
            foreach (string column in columnsToUpdate)
            {
                Console.Write($"Enter new {column}: ");
                string newValue = Console.ReadLine();
                updateColumns.Add(column, newValue);
            }

            Console.Write("Insert column name as primary key: ");
            string primaryKeyName = Console.ReadLine();

            Console.Write("Insert value of primary key: ");
            object primaryKeyValue = Console.ReadLine();

            var u = new Universities();
            var university = new Universities();
            var result = u.UpdateUniversity(university);

            var view = new UniversityView();
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
            var university = new Universities();
            Console.Write("Insert number of row: ");
            university.Id = Convert.ToInt32(Console.ReadLine());
            var u = new Universities();
            var result = u.DeleteUniversityById(university);
            var view = new UniversityView();
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
