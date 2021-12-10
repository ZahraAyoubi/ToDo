using Microsoft.AspNetCore.Identity;

namespace ToDo.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
    }
}
