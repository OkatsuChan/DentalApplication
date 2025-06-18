using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldtblPatientRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessed",
                table: "tblPatientRecord",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateCreated",
                table: "tblPatientRecord",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tblPatientRecord");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastAccessed",
                table: "tblPatientRecord",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
