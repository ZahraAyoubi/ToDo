using Microsoft.EntityFrameworkCore;
using UserManagement.Service.APIProject.Models;

namespace UserManagement.Service.APIProject.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<User> AspNetUsers { get; set; }
    }
}
