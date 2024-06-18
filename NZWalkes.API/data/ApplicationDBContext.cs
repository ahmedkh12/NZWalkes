using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NZWalkes.API.Models;
using System.Collections.Generic;
using System.Net.Sockets;

namespace NZWalkes.API.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }



        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<RegionModel> Regions { get; set; } = default!;
        public DbSet<Walk> Walks { get; set; } = default!;
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; } = default!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var diffculties = new List<WalkDifficulty>()
            {
                new WalkDifficulty()
                {
                    Id = Guid.Parse("436a1bd0-e8c6-48e6-b55d-6ea25f51100c"),
                    Code = "Easy"
                }
                ,
                 new WalkDifficulty()
                {
                    Id = Guid.Parse("a06a0de4-c8bd-412e-9176-46fd314d333a"),
                    Code = "Hard"
                },

                  new WalkDifficulty()
                {
                    Id = Guid.Parse("90c72a00-8d60-4d14-afaf-63fcc2716ce1"),
                    Code = "Medieum"
                }
            };

            // seeding data into database
            modelBuilder.Entity<WalkDifficulty>().HasData(diffculties);


            var Regions = new List<RegionModel>() 
            {
            new RegionModel
            { 
                Id = Guid.Parse("1c39e209-b65f-43b7-b636-48827a3e8f47"),
                Code = "Test Code1",
                Name = "Test Name 1 ",
                RegionImageUrl = "Test Image Url1 "
            },

                 new RegionModel
            {
                Id = Guid.Parse("f8843075-1b5c-4495-80ba-a470a343e0b2"),
                Code = "Test Code2",
                Name = "Test Name 2 ",
                RegionImageUrl = "Test Image Url2 "
            },

                      new RegionModel
            {
                Id = Guid.Parse("eeadef98-d91c-4f6f-8834-2e8b03749543"),
                Code = "Test Code 3",
                Name = "Test Name 3 ",
                RegionImageUrl = "Test Image Url3 "
            },

                           new RegionModel
            {
                Id = Guid.Parse("a8076ec9-02f5-4226-bc54-f53704a49be9"),
                Code = "Test Code4",
                Name = "Test Name 4 ",
                RegionImageUrl = "Test Image Url4 "
            },
            };


            modelBuilder.Entity<RegionModel>().HasData(Regions);

        }


    }
}
