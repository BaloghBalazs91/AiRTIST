using Microsoft.EntityFrameworkCore;
using AiRTIST.Model;
using AiRTIST.Enum;

namespace AiRTIST.Data
{
    public class AiRTISTDBContext : DbContext
    {
        public DbSet<Poem> Poets { get; set; }

        public AiRTISTDBContext(DbContextOptions<AiRTISTDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poem>()
                .HasKey(p => p.PoemId); // Assuming "PoetId" is your primary key property

            modelBuilder.Entity<Poem>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}

