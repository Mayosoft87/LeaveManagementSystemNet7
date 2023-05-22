
using LeaveManagementSystem.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "4fbcdf33-11f2-495c-ada3-5d40dc997581",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                 new IdentityRole
                 {
                     Id = "5fbcdf44-11f3-495c-ada4-6d50dc997581",
                     Name = Roles.User,
                     NormalizedName = Roles.User.ToUpper()
                 }
            );
        }
    }
}