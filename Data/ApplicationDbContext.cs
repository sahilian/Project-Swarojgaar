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
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    { Id = "65c00570-b09f-4c8b-a412-eea238c829b7", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole
                {
                    Id = "64a99865-2144-4979-942e-71a8540d5061", Name = "Job_Provider", NormalizedName = "JOB_PROVIDER"
                },
                new IdentityRole
                    { Id = "d959fac3-736d-437f-b467-00bce9b64a65", Name = "Job_Seeker", NormalizedName = "JOB_SEEKER" }
            );
            var adminId = Guid.NewGuid().ToString();
            // Seed Admin User
            var adminUser = new IdentityUser
            {
                Id = adminId, // Generate a unique ID for the admin user
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = "UniqueSecurityStamp"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(null, "Secret123$");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // Assign Admin Role to Admin User
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "65c00570-b09f-4c8b-a412-eea238c829b7" }
            );

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany()
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Add this line to avoid cascading delete

            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.User)
                .WithMany()
                .HasForeignKey(sj => sj.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Add this line to avoid cascading delete
        }
    }
}

