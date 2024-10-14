using Microsoft.EntityFrameworkCore;
using Walkistan.API.Models.Domain;

namespace Walkistan.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Regions

            var regions = new List<Region>
            {
                new Region
                {
                    Id = 1183,
                    Name = "Besiktas",
                },

                new Region
                {
                    Id = 1185,
                    Name = "Beykoz",
                },

                new Region
                {
                    Id = 1421,
                    Name = "Kadikoy"
                },

                new Region
                {
                    Id = 1708,
                    Name = "Uskudar"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);

            // Seed Difficulty

            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = 1,
                    Name = "Easy"
                },

                new Difficulty
                {
                    Id = 2,
                    Name = "Medium",
                },

                new Difficulty
                {
                    Id = 3,
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}
