namespace API.Model
{
    public class Bookings
    {
        public Guid Guid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int Remarks { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
        public Guid Room_Guid { get; set; }
        public Guid Employee_Guid { get; set; }

    }
}
