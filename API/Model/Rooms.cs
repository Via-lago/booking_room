namespace API.Model
{
    public class Rooms
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
    }
}
