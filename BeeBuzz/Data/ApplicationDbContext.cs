using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // db sets
        public DbSet<Organizations> OrganizationsSet { get; set; }
        public DbSet<ApplicationUsers> UsersSet { get; set; }
        public DbSet<BeeHives> BeeHivesSet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // organization to user
            modelBuilder.Entity<ApplicationUsers>()
                .HasOne(organization => organization.Organization)
                .WithMany(h => h.Users)
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);



            // Hackathon - Organizer relationship
            modelBuilder.Entity<BeeHives>()
                .HasOne(beehive => beehive.User)        // one user
                .WithMany(u => u.ManagedBeeHives)       // that managed beehives
                .HasForeignKey(u => u.BeeHiveUserId)    // with a huser id
                .OnDelete(DeleteBehavior.Restrict);     // delete behavior 

            

           
        }
    }
}
