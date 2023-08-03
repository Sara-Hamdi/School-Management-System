using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Areas.Identity.Data;
using School.Models;
namespace School.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>().HasKey(t => new { t.StudentId, t.SubjectId });
        }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<Subject> subject { get; set; }
        public DbSet<Enrollment> enrollment { get; set; }



    }
}
