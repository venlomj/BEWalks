using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BEWalks.API.Data
{
    public class BEWalksAuthDbContext : IdentityDbContext
    {
        public BEWalksAuthDbContext(DbContextOptions<BEWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "18297563-56e6-4109-b5ac-ae85283bc457";
            var writerRoleId = "92b9e3a8-1868-4efe-b9d0-e9d8fec9a538";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
