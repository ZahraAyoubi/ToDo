using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ToDo.Services.Indentity.DbContexts;
using ToDo.Services.Indentity.Models;

namespace ToDo.Services.Indentity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser>_userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Administration).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Administration)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.User)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111",
                FisrtName ="Zahra",
                LastName ="Admin",
            };

            _userManager.CreateAsync(admin, "Admin123*").GetAwaiter().GetResult();
            _userManager.CreateAsync(admin, SD.Administration).GetAwaiter().GetResult();

            var tem1 = _userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,admin.FisrtName +" "+ admin.LastName),
                new Claim(JwtClaimTypes.GivenName,admin.FisrtName),
                new Claim(JwtClaimTypes.FamilyName,admin.LastName),
                new Claim(JwtClaimTypes.Role,SD.Administration)
            }).Result;

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "user1@gmail.com",
                Email = "user1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111",
                FisrtName = "Zahra",
                LastName = "user",
            };

            _userManager.CreateAsync(user, "User123*").GetAwaiter().GetResult();
            _userManager.CreateAsync(user, SD.User).GetAwaiter().GetResult();

            var tem2 = _userManager.AddClaimsAsync(user, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,user.FisrtName +" "+ user.LastName),
                new Claim(JwtClaimTypes.GivenName,user.FisrtName),
                new Claim(JwtClaimTypes.FamilyName,user.LastName),
                new Claim(JwtClaimTypes.Role,SD.User)
            }).Result;
        }
    }
}
