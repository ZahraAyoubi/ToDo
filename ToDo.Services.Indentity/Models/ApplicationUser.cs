using Microsoft.AspNetCore.Identity;

namespace ToDo.Services.Indentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FisrtName { get; set;}
        public string LastName { get; set;}
    }
}
