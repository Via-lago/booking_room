using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Model
{
    public class Bookings
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Remarks { get; set; }
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
    }
}
