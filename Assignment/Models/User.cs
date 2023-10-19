namespace Assignment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; } = DateTime.Now;
    }
}
