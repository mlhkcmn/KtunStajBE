namespace Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }

    public class UserLogin
    {
        public string Email {get; set;}
        public string Password {get; set;}
    }
}