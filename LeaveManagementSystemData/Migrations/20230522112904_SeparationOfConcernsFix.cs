using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeparationOfConcernsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58de75dd-31ff-4c96-84e9-bad26e9be227", "AQAAAAIAAYagAAAAEE5xKeLxfrcGkbgoC+1oz0tbQdM78InMWJELZXmjjeXL+7M8cd/5c/NXJvaU271dbA==", "0976249e-28e3-4340-9a22-5daf584da275" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d098bbd6-ff1d-4600-9101-fb60bb8702c5", "AQAAAAIAAYagAAAAEGba+n5W3BTmMfXKIhWjYovdg1K3KKQvLCpomDmVmM8sN/zW/mSLyjpuIjS/OsWgFw==", "0017eb3d-eaa1-4579-bca0-35dcd359d458" });
        }
    }
}
