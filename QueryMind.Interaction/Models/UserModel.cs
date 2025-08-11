namespace QueryMind.Interaction.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
    
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
