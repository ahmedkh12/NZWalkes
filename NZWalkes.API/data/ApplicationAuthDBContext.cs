using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalkes.API.data
{
    public class ApplicationAuthDBContext : IdentityDbContext
    {
        public ApplicationAuthDBContext(DbContextOptions<ApplicationAuthDBContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "451ecfa3-0fa7-4cad-9830-bd8011fbbe82";
            var writerId = "1d4619ea-d3c8-4870-b40b-f3d63431f7f1";

            var Roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                }
                ,new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }
            };


            builder.Entity<IdentityRole>().HasData(Roles);

        }
    }
}
