namespace API.Model
{
    public class Employees
    {
        public Guid Guid { get; set; }
        public string NIK { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Gender { get; set; }
        public DateTime Hiring_date { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
    }
}
