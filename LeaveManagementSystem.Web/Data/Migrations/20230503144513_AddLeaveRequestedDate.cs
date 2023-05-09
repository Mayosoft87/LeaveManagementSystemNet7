using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveRequestedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequested",
                table: "leaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817ce529-3da8-4294-a222-2e5e40894659", "AQAAAAIAAYagAAAAEJFheQ6ONf25Xq2exHEHOS5ANGy4EARKCVyOAUcMXtzpOXaVf7u829xTsCc4CUZoDA==", "8cb3be6b-1636-403d-bbd9-b8ea1d487852" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRequested",
                table: "leaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a076bd1-79be-4e2a-9af8-b01f95287278", "AQAAAAIAAYagAAAAEL3UTkN9hA/UaVazfOj4Me1QUXzxGffOgZk19fuidPQnfzyvyDNz/2N+obaZqrxolw==", "19a12ce6-7a19-4563-b92d-85cd9c645c7a" });
        }
    }
}
