using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollOff_Test4API.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    GlobalGroupID = table.Column<int>(type: "int", nullable: false)
                        ,
                    EmployeeNo = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectCode = table.Column<int>(type: "int", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeopleManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Practice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewGlobalPractice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.GlobalGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackForms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlobalGroupID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimarySkill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<double>(type: "float", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Practice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollOffEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForRollOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThisReleaseNeedsBackfillIsBackfilled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformanceIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resigned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnderProbation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongLeave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Communication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleCompetencies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelevantExperienceYears = table.Column<double>(type: "float", nullable: true),
                    EmployeeNumber = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackForms", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FeedbackForms_Employees_GlobalGroupID",
                        column: x => x.GlobalGroupID,
                        principalTable: "Employees",
                        principalColumn: "GlobalGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackForms_GlobalGroupID",
                table: "FeedbackForms",
                column: "GlobalGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackForms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
