using BEWalks.API.Models.Domain;
using BEWalks.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BEWalks.API.Data
{
    public static class BEWalksDbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = DifficultyType.Easy.ToString(),
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = DifficultyType.Medium.ToString(),
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = DifficultyType.Hard.ToString(),
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Belgium Regions
            var regions = new List<Region>
            {
                // Main regions of Belgium
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Flanders",
                    Code = "VLG",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/Flag_of_Flanders.svg/1200px-Flag_of_Flanders.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Wallonia",
                    Code = "WAL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Flag_of_Wallonia.svg/1200px-Flag_of_Wallonia.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Brussels-Capital",
                    Code = "BRU",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Flag_of_the_Brussels-Capital_Region.svg/1200px-Flag_of_the_Brussels-Capital_Region.svg.png"
                },

                // Additional sub-regions or provinces
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Antwerp",
                    Code = "ANT",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Antwerp.svg/1200px-Flag_of_Antwerp.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Liège",
                    Code = "LIE",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Flag_of_Liège.svg/1200px-Flag_of_Liège.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Luxembourg",
                    Code = "LUX",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Luxembourg_%28province%29.svg/1200px-Flag_of_Luxembourg_%28province%29.svg.png"
                }
            };

            // Seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}