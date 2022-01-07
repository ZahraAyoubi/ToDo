namespace UserManagement.Service.APIProject.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
