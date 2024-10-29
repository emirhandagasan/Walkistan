using Microsoft.EntityFrameworkCore;
using Walkistan.API.Models.Domain;

namespace Walkistan.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Regions

            var regions = new List<Region>
            {
                new Region
                {
                    Id = 1103,
                    Name = "Adalar",
                    RegionImageUrl = "https://images.unsplash.com/photo-1518352753950-d0c7da80e7a8"
                },

                new Region
                {
                    Id = 1183,
                    Name = "Besiktas",
                    RegionImageUrl = "https://images.unsplash.com/photo-1589906528014-454c84ebaa5b"
                },

                new Region
                {
                    Id = 1186,
                    Name = "Beyoglu",
                    RegionImageUrl = "https://images.unsplash.com/photo-1635357558138-df7ae85a3f61"
                },

                new Region
                {
                    Id = 1185,
                    Name = "Beykoz",
                    RegionImageUrl = "https://images.unsplash.com/photo-1709458915635-4ba2e6076d6e"
                },

                new Region
                {
                    Id = 1421,
                    Name = "Kadikoy",
                    RegionImageUrl = "https://images.unsplash.com/photo-1689410763484-d7fd8c775e25"
                },

                new Region
                {
                    Id = 1708,
                    Name = "Uskudar",
                    RegionImageUrl = "https://images.unsplash.com/photo-1719954270201-4afb0efe559e"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);



            // Seed Difficulties

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



            // Seed Walks

            var walks = new List<Walk>
            {
                new Walk
                {
                    Id = 1,
                    Name = "Uskudar Coast Walk",
                    Description = "This coastal walk takes you along the unique Maiden's Tower",
                    LengthInKm = 3,
                    WalkImageUrl = "https://images.unsplash.com/photo-1709940748754-eb59888100af",
                    DifficultyId = 1,
                    RegionId = 1708
                },

                new Walk
                {
                    Id = 2,
                    Name = "Caddebostan Walk",
                    Description = "Explore the beautiful Caddebostan Shore of Kadikoy on this leisurely walk",
                    LengthInKm = 5,
                    WalkImageUrl = "https://images.unsplash.com/photo-1607856339700-5520108d5f7c",
                    DifficultyId = 2,
                    RegionId = 1421
                },

                new Walk
                {
                    Id = 3,
                    Name = "Istiklal Street",
                    Description = "A walk from Taksim to Besiktas. This walk includes many historical places like Galata Tower, Dolmabahce and more",
                    LengthInKm = 8,
                    WalkImageUrl = "https://images.unsplash.com/photo-1607856339700-5520108d5f7c",
                    DifficultyId = 2,
                    RegionId = 1186,
                },

                new Walk
                {
                    Id = 4,
                    Name = "Heybeliada",
                    Description = "We start this route, which is 7 kilometers and takes approximately 2 hours in total, " +
                    "excluding rest time, from Heybeliada Ferry Port. The route offers us a unique natural landscape track " +
                    "where blue and green mix. Heybeliada is such a beautiful place that when you complete this route, " +
                    "you are not only satisfied in terms of sports. The route also brings you many points of interest that you can visit.",
                    LengthInKm = 7,
                    WalkImageUrl = "https://images.unsplash.com/photo-1721229902006-ab891d8dae87",
                    DifficultyId = 2,
                    RegionId = 1103,
                },

                new Walk
                {
                    Id = 5,
                    Name = "Besiktas to Bebek",
                    Description = "A 10 km walk from the Ferry Port of Besiktas to Bebek.",
                    LengthInKm = 10,
                    WalkImageUrl = "https://images.unsplash.com/photo-1717150982298-1df8a5c0f342",
                    DifficultyId = 2,
                    RegionId = 1183,
                },
            };

            modelBuilder.Entity<Walk>().HasData(walks);
        }
    }
}
