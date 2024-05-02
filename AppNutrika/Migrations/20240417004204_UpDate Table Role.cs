using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class UpDateTableRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "creatAt",
                table: "roleOfUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creatAt",
                table: "roleOfUsers");
        }
    }
}
