namespace API.Model
{
    public class AccountRoles
    {
        public Guid Guid { get; set; }
        public Guid Account_guid { get; set; }
        public Guid Role_guid { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
    }
}
