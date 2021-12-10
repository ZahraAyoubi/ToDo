using Microsoft.EntityFrameworkCore;
using ToDoList.Service.APIProject.Models;

namespace ToDoList.Service.APIProject.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<ToDoListModel> ToDoLists { get; set; }
    }
}
