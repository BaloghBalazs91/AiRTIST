using Microsoft.EntityFrameworkCore;
using AiRTIST.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AiRTIST.Data
{
    public class AiRTISTDBContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Poem> Poems { get; set; }

        public AiRTISTDBContext(DbContextOptions<AiRTISTDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Poem>()
                .HasKey(p => p.PoemId);

            modelBuilder.Entity<Poem>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}