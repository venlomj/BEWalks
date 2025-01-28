using BEWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BEWalks.API.Data
{
    public class BEWalksDbContext : DbContext
    {
        public BEWalksDbContext(DbContextOptions<BEWalksDbContext> options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BEWalksDbSeeder.Seed(modelBuilder);
        }
    }
}
