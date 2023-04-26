using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DBSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fbcdf33-11f2-495c-ada3-5d40dc997581", null, "Administrator", "ADMINISTRATOR" },
                    { "5fbcdf44-11f3-495c-ada4-6d50dc997581", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fbcdf44-11f3-496c-ada4-5d40dc997600", 0, "c96577b1-6046-4ff4-840f-877636508488", null, null, "Administrator@Email.ie", false, "System", "Admin", false, null, "ADMINISTRATOR@EMAIL.IE", null, "AQAAAAIAAYagAAAAEGvvL2DFqnrTNOb6D9xAMtoPQ2A9ZsnEt3VU6gTrPjM7W1wljbEopN4etnJsU0t10Q==", null, false, "b07d52a2-43d6-4da0-8964-8052e75589a3", null, false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4fbcdf33-11f2-495c-ada3-5d40dc997581", "4fbcdf44-11f3-496c-ada4-5d40dc997600" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fbcdf44-11f3-495c-ada4-6d50dc997581");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fbcdf33-11f2-495c-ada3-5d40dc997581", "4fbcdf44-11f3-496c-ada4-5d40dc997600" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fbcdf33-11f2-495c-ada3-5d40dc997581");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600");
        }
    }
}
