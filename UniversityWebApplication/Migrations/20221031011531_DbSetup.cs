using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityWebApplication.Migrations
{
    public partial class DbSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Serial = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Entitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Serial);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClubID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Clubs_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Clubs",
                        principalColumn: "Serial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Faculties_Instructors_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => new { x.CourseID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Serial", "Entitle" },
                values: new object[,]
                {
                    { "C", "Cityzen" },
                    { "D", "Devil Art" },
                    { "G", "Germanium" },
                    { "H", "Huskar" },
                    { "M", "Mylioanic" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "ID", "Name", "SupervisorID" },
                values: new object[] { 3, "Networking", null });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Joe Root" },
                    { 2, "Eoin Morgan" },
                    { 3, "Jos Buttler" },
                    { 4, "Jonny Bairstow" },
                    { 5, "Ben Stokes" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Credits", "FacultyID", "Title" },
                values: new object[] { 8, 45, 3, "Introduction to UI/UX" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "ID", "Name", "SupervisorID" },
                values: new object[,]
                {
                    { 1, "Computing", 4 },
                    { 2, "Multimedia", 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "ClubID", "EnrollmentDate", "Name" },
                values: new object[,]
                {
                    { 1, "C", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Traxex Diablo" },
                    { 2, "M", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johan Sundestein" },
                    { 3, "D", new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anathan Stone" },
                    { 4, "H", new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tommy Vercitty" },
                    { 5, "D", new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony Martial" },
                    { 6, "H", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcus Rashford" },
                    { 7, "G", new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz Antony" },
                    { 8, "M", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prophet Heir" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseID", "InstructorID" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Credits", "FacultyID", "Title" },
                values: new object[,]
                {
                    { 1, 15, 1, "Programming" },
                    { 2, 20, 1, "Emerging Platforms and Technologies" },
                    { 3, 25, 1, "Advanced Databases" },
                    { 4, 30, 1, "Introduction to Artificial Intelligence" },
                    { 5, 15, 1, "Application Development" },
                    { 6, 30, 2, "Networking and Advanced Security" },
                    { 7, 45, 2, "Linux: Commands and Tools" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseID", "StudentID", "ID", "Marks" },
                values: new object[,]
                {
                    { 8, 4, 1011, 90 },
                    { 8, 5, 1013, null }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseID", "InstructorID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 5 },
                    { 5, 2 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseID", "StudentID", "ID", "Marks" },
                values: new object[,]
                {
                    { 1, 1, 1001, 90 },
                    { 1, 2, 1005, 32 },
                    { 1, 4, 1008, null },
                    { 1, 6, 1014, null },
                    { 1, 7, 1015, 54 },
                    { 2, 1, 1002, 56 },
                    { 2, 2, 1003, 78 },
                    { 2, 3, 1006, 88 },
                    { 2, 4, 1009, 70 },
                    { 2, 8, 1018, 78 },
                    { 3, 2, 1004, 45 },
                    { 4, 3, 1007, null },
                    { 5, 4, 1010, 75 },
                    { 6, 5, 1012, 67 },
                    { 6, 7, 1016, 55 },
                    { 7, 8, 1017, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_InstructorID",
                table: "CourseAssignments",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyID",
                table: "Courses",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_SupervisorID",
                table: "Faculties",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClubID",
                table: "Students",
                column: "ClubID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
