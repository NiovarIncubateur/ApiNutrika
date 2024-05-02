using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class MiseajourProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "apportEau",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "apportProvende",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eauRestant",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eauUtilise",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "libelleTraitement",
                table: "production",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observation",
                table: "production",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "provendeRestant",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "provendeUtilise",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apportEau",
                table: "production");

            migrationBuilder.DropColumn(
                name: "apportProvende",
                table: "production");

            migrationBuilder.DropColumn(
                name: "eauRestant",
                table: "production");

            migrationBuilder.DropColumn(
                name: "eauUtilise",
                table: "production");

            migrationBuilder.DropColumn(
                name: "libelleTraitement",
                table: "production");

            migrationBuilder.DropColumn(
                name: "observation",
                table: "production");

            migrationBuilder.DropColumn(
                name: "provendeRestant",
                table: "production");

            migrationBuilder.DropColumn(
                name: "provendeUtilise",
                table: "production");
        }
    }
}
