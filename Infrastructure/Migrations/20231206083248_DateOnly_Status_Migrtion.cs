using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DateOnly_Status_Migrtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditedTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreditedTime",
                table: "Exercises");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreditedDate",
                table: "Lessons",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCredited",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreditedDate",
                table: "Exercises",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreditedDate",
                table: "ExerciseBlocks",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCredited",
                table: "ExerciseBlocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ExerciseBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreditedDate",
                table: "Disciplines",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCredited",
                table: "Disciplines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Disciplines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreditedDate",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CreditedDate",
                table: "ExerciseBlocks");

            migrationBuilder.DropColumn(
                name: "IsCredited",
                table: "ExerciseBlocks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExerciseBlocks");

            migrationBuilder.DropColumn(
                name: "CreditedDate",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "IsCredited",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Disciplines");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditedTime",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCredited",
                table: "Exercises",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditedTime",
                table: "Exercises",
                type: "datetime2",
                nullable: true);
        }
    }
}
