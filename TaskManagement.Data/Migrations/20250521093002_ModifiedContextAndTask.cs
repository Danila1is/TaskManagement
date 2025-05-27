using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedContextAndTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStart",
                table: "Tasks",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "TaskEnd",
                table: "Tasks",
                newName: "DateEnd");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDone",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Staffs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Staffs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DateDone",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Staffs");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Tasks",
                newName: "TaskStart");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Tasks",
                newName: "TaskEnd");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Staffs",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "NOW()");
        }
    }
}
