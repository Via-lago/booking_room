using booking_room.Context;
using booking_room.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Model
{
    public class Employee
    {
        public string Id { get; set; }
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }

    }
}
