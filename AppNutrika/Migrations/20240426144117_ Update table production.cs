using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class Updatetableproduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "production");
        }
    }
}
