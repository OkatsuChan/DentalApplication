using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdatetblPatientRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessedBy",
                table: "tblPatientRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastAccessed",
                table: "tblPatientRecord",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonforAccess",
                table: "tblPatientRecord",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessedBy",
                table: "tblPatientRecord");

            migrationBuilder.DropColumn(
                name: "LastAccessed",
                table: "tblPatientRecord");

            migrationBuilder.DropColumn(
                name: "ReasonforAccess",
                table: "tblPatientRecord");
        }
    }
}
