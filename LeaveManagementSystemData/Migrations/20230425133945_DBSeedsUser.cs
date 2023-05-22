using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DBSeedsUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e76760e6-4eb8-4c39-b1cc-5d1325816b7f", true, "ADMINISTRATOR@EMAIL.IE", "AQAAAAIAAYagAAAAEHXAJOWpl2823GnoRoJ/+BhL0M31QtksLKObpJ1ZCUe0/kAMxgXXm8Xg/0cGQDwqoA==", "2c97bb45-dfd0-416f-aae2-7a904702f6ec", "Administrator@Email.ie" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c96577b1-6046-4ff4-840f-877636508488", false, null, "AQAAAAIAAYagAAAAEGvvL2DFqnrTNOb6D9xAMtoPQ2A9ZsnEt3VU6gTrPjM7W1wljbEopN4etnJsU0t10Q==", "b07d52a2-43d6-4da0-8964-8052e75589a3", null });
        }
    }
}
