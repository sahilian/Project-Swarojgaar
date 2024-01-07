using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Models;

namespace Swarojgaar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<Resume> Resumes { get; set; }
        //public DbSet<Shortlisted> Shortlisted { get; set; }

    }
}
