namespace API.Model
{
    public class Education
    {
        public Guid Guid { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public float Gpa { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
        public Guid University_guid { get; set; }   

    }
}
