using Microsoft.AspNetCore.Identity;

namespace UserManagement.Service.APIProject.Models
{
    public class User : IdentityUser
    {
        //[Required]
        //public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        //public string RoleName { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        //[Required]
        //public bool EmailConfirmed { get; set; }
        //public string Password { get; set; }
        //public string PasswordHash { get; set; }
        //public string PhoneNumber { get; set; }
        //[Required]
        //public bool PhoneNumberConfirmed { get; set; }
        //[Required]
        //public bool TwoFactorEnabled { get; set; }
        //[Required]
        //public bool LockoutEnabled { get; set; }
        //public int AccessFailedCount { get; set; }
        //public string ReturnUrl { get; set; }
        //public string RoleName { get; set; }
        //public bool AllowRememberLogin { get; set; }
        //public bool EnableLocalLogin { get; set; } = true;
    }
}
