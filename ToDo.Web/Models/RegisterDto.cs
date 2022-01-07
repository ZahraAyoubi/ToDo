namespace ToDo.Web.Models
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string RoleName { get; set; }
        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; } = true;
    }
}
