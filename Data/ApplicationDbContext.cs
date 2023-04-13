using Microsoft.EntityFrameworkCore;
using School.Models;
namespace School.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<UserAccount> userAccount { get; set; }

    }
}
