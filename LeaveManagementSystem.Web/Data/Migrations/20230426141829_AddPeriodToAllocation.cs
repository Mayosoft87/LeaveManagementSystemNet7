using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5594edf5-fedd-467d-ad85-bde4b2bfaffc", "AQAAAAIAAYagAAAAEFwH6G4npvEfWR+lX9qKObiWSkpeHIn3oCzr3E7UJQ/mDx7PsVF9YZ0DEybjthEG5Q==", "9eb23702-b3e7-4947-a4ed-49c27a03b445" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e76760e6-4eb8-4c39-b1cc-5d1325816b7f", "AQAAAAIAAYagAAAAEHXAJOWpl2823GnoRoJ/+BhL0M31QtksLKObpJ1ZCUe0/kAMxgXXm8Xg/0cGQDwqoA==", "2c97bb45-dfd0-416f-aae2-7a904702f6ec" });
        }
    }
}
