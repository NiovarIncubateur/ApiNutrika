using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class UpdateallTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consommation_categorieOfConsommation_categorieOfConsommationid",
                table: "Consommation");

            migrationBuilder.DropForeignKey(
                name: "FK_production_Consommation_consommationid",
                table: "production");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consommation",
                table: "Consommation");

            migrationBuilder.RenameTable(
                name: "Consommation",
                newName: "consommation");

            migrationBuilder.RenameColumn(
                name: "libelle",
                table: "traitement",
                newName: "libelleTraitement");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "traitement",
                newName: "descriptionTraitement");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "observation",
                newName: "observation");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "consommation",
                newName: "qteServie");

            migrationBuilder.RenameColumn(
                name: "categorieOfConsommationategoryid",
                table: "consommation",
                newName: "archived");

            migrationBuilder.RenameIndex(
                name: "IX_Consommation_categorieOfConsommationid",
                table: "consommation",
                newName: "IX_consommation_categorieOfConsommationid");

            migrationBuilder.AddColumn<int>(
                name: "effectifMort",
                table: "production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_consommation",
                table: "consommation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_consommation_categorieOfConsommation_categorieOfConsommationid",
                table: "consommation",
                column: "categorieOfConsommationid",
                principalTable: "categorieOfConsommation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_production_consommation_consommationid",
                table: "production",
                column: "consommationid",
                principalTable: "consommation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consommation_categorieOfConsommation_categorieOfConsommationid",
                table: "consommation");

            migrationBuilder.DropForeignKey(
                name: "FK_production_consommation_consommationid",
                table: "production");

            migrationBuilder.DropPrimaryKey(
                name: "PK_consommation",
                table: "consommation");

            migrationBuilder.DropColumn(
                name: "effectifMort",
                table: "production");

            migrationBuilder.RenameTable(
                name: "consommation",
                newName: "Consommation");

            migrationBuilder.RenameColumn(
                name: "libelleTraitement",
                table: "traitement",
                newName: "libelle");

            migrationBuilder.RenameColumn(
                name: "descriptionTraitement",
                table: "traitement",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "observation",
                table: "observation",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "qteServie",
                table: "Consommation",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "archived",
                table: "Consommation",
                newName: "categorieOfConsommationategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_consommation_categorieOfConsommationid",
                table: "Consommation",
                newName: "IX_Consommation_categorieOfConsommationid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consommation",
                table: "Consommation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consommation_categorieOfConsommation_categorieOfConsommationid",
                table: "Consommation",
                column: "categorieOfConsommationid",
                principalTable: "categorieOfConsommation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_production_Consommation_consommationid",
                table: "production",
                column: "consommationid",
                principalTable: "Consommation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
