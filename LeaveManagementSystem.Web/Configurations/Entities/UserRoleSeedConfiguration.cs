using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                    {
                    RoleId = "4fbcdf33-11f2-495c-ada3-5d40dc997581",
                    UserId = "4fbcdf44-11f3-496c-ada4-5d40dc997600"
                     }
            );
        }
    }
}