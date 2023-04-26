using LeaveManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                    Email = "Administrator@Email.ie",
                    NormalizedEmail = "ADMINISTRATOR@EMAIL.IE",
                    UserName = "Administrator@Email.ie",
                    NormalizedUserName = "ADMINISTRATOR@EMAIL.IE",
                    EmailConfirmed = true,
                    Firstname ="System",
                    Lastname = "Admin",
                    PasswordHash = hasher.HashPassword(null,"P@ssword1")

                }  
                 
            );
        }
    }
}