using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    TutorFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Student_ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_GroupNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Student_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonNumber = table.Column<int>(type: "int", nullable: false),
                    MarkType = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCredited = table.Column<bool>(type: "bit", nullable: true),
                    CreditedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theory_ContentType = table.Column<int>(type: "int", nullable: true),
                    Theory_ReadOnly = table.Column<bool>(type: "bit", nullable: true),
                    Theory_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SubType = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theory_ContentType = table.Column<int>(type: "int", nullable: false),
                    Theory_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Theory_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralInformation_ContentType = table.Column<int>(type: "int", nullable: false),
                    GeneralInformation_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    GeneralInformation_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseBlocks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreditedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCredited = table.Column<bool>(type: "bit", nullable: true),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    ExerciseNumber = table.Column<int>(type: "int", nullable: false),
                    ExerciseVariant = table.Column<int>(type: "int", nullable: true),
                    MarkType = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ExerciseBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Example_ContentType = table.Column<int>(type: "int", nullable: false),
                    Example_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Example_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodicalInstructions_ContentType = table.Column<int>(type: "int", nullable: false),
                    MethodicalInstructions_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MethodicalInstructions_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseBlocks_ExerciseBlockId",
                        column: x => x.ExerciseBlockId,
                        principalTable: "ExerciseBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerFormat = table.Column<int>(type: "int", nullable: false),
                    OptionType = table.Column<int>(type: "int", nullable: false),
                    OptionNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer_ContentType = table.Column<int>(type: "int", nullable: false),
                    Answer_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Answer_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerOption_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOption_ExerciseId",
                table: "AnswerOption",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseBlocks_LessonId",
                table: "ExerciseBlocks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseBlockId",
                table: "Exercises",
                column: "ExerciseBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DisciplineId",
                table: "Lessons",
                column: "DisciplineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerOption");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseBlocks");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
