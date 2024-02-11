using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIEMS.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptMaster",
                columns: table => new
                {
                    DeptCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptMaster", x => x.DeptCode);
                });

            migrationBuilder.CreateTable(
                name: "EmpProfile",
                columns: table => new
                {
                    EmpCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptCode = table.Column<int>(type: "int", nullable: false),
                    DeptMasterDeptCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfile", x => x.EmpCode);
                    table.ForeignKey(
                        name: "FK_EmpProfile_DeptMaster_DeptMasterDeptCode",
                        column: x => x.DeptMasterDeptCode,
                        principalTable: "DeptMaster",
                        principalColumn: "DeptCode");
                });

            migrationBuilder.InsertData(
                table: "DeptMaster",
                columns: new[] { "DeptCode", "DeptName" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Finance" },
                    { 3, "IT" },
                    { 4, "Marketing" },
                    { 5, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "EmpProfile",
                columns: new[] { "EmpCode", "DateOfBirth", "DeptCode", "DeptMasterDeptCode", "Email", "EmpName" },
                values: new object[,]
                {
                    { 101, new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "johndoe@example.com", "John Doe" },
                    { 102, new DateTime(1990, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "janedoe@example.com", "Jane Doe" },
                    { 103, new DateTime(1988, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "jimbeam@example.com", "Jim Beam" },
                    { 104, new DateTime(1992, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "jackdaniels@example.com", "Jack Daniels" },
                    { 105, new DateTime(1986, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "josecuervo@example.com", "Jose Cuervo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfile_DeptMasterDeptCode",
                table: "EmpProfile",
                column: "DeptMasterDeptCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpProfile");

            migrationBuilder.DropTable(
                name: "DeptMaster");
        }
    }
}
