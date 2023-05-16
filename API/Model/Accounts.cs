namespace API.Model
{
    public class Accounts
    {
        public Guid Guid { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
    }
}
