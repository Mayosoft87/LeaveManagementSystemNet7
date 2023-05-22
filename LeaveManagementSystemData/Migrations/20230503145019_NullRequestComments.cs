using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullRequestComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "leaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d098bbd6-ff1d-4600-9101-fb60bb8702c5", "AQAAAAIAAYagAAAAEGba+n5W3BTmMfXKIhWjYovdg1K3KKQvLCpomDmVmM8sN/zW/mSLyjpuIjS/OsWgFw==", "0017eb3d-eaa1-4579-bca0-35dcd359d458" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "leaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817ce529-3da8-4294-a222-2e5e40894659", "AQAAAAIAAYagAAAAEJFheQ6ONf25Xq2exHEHOS5ANGy4EARKCVyOAUcMXtzpOXaVf7u829xTsCc4CUZoDA==", "8cb3be6b-1636-403d-bbd9-b8ea1d487852" });
        }
    }
}
