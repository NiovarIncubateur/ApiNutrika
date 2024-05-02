using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_production_consommation_consommationid",
                table: "production");

            migrationBuilder.DropIndex(
                name: "IX_production_consommationid",
                table: "production");

            migrationBuilder.RenameColumn(
                name: "descriptionTraitement",
                table: "traitement",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "consommationid",
                table: "production",
                newName: "archived");

            migrationBuilder.AddColumn<int>(
                name: "productionid",
                table: "consommation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_consommation_productionid",
                table: "consommation",
                column: "productionid");

            migrationBuilder.AddForeignKey(
                name: "FK_consommation_production_productionid",
                table: "consommation",
                column: "productionid",
                principalTable: "production",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consommation_production_productionid",
                table: "consommation");

            migrationBuilder.DropIndex(
                name: "IX_consommation_productionid",
                table: "consommation");

            migrationBuilder.DropColumn(
                name: "productionid",
                table: "consommation");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "traitement",
                newName: "descriptionTraitement");

            migrationBuilder.RenameColumn(
                name: "archived",
                table: "production",
                newName: "consommationid");

            migrationBuilder.CreateIndex(
                name: "IX_production_consommationid",
                table: "production",
                column: "consommationid");

            migrationBuilder.AddForeignKey(
                name: "FK_production_consommation_consommationid",
                table: "production",
                column: "consommationid",
                principalTable: "consommation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
