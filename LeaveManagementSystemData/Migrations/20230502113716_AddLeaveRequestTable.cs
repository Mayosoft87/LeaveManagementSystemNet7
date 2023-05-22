using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a076bd1-79be-4e2a-9af8-b01f95287278", "AQAAAAIAAYagAAAAEL3UTkN9hA/UaVazfOj4Me1QUXzxGffOgZk19fuidPQnfzyvyDNz/2N+obaZqrxolw==", "19a12ce6-7a19-4563-b92d-85cd9c645c7a" });

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_LeaveTypeId",
                table: "leaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbcdf44-11f3-496c-ada4-5d40dc997600",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5594edf5-fedd-467d-ad85-bde4b2bfaffc", "AQAAAAIAAYagAAAAEFwH6G4npvEfWR+lX9qKObiWSkpeHIn3oCzr3E7UJQ/mDx7PsVF9YZ0DEybjthEG5Q==", "9eb23702-b3e7-4947-a4ed-49c27a03b445" });
        }
    }
}
