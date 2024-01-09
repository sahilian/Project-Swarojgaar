using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Models;

namespace Swarojgaar.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<Resume> Resumes { get; set; }
        //public DbSet<Shortlisted> Shortlisted { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany()
                .HasForeignKey(ja => ja.UserId);

            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.User)
                .WithMany()
                .HasForeignKey(sj => sj.UserId);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

        }

    }
}
