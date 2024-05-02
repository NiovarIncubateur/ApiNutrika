using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNutrika.Migrations
{
    /// <inheritdoc />
    public partial class BeginProjet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorieOfConsommation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorieOfConsommation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "materiels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    qteUtilise = table.Column<int>(type: "int", nullable: false),
                    qteReste = table.Column<int>(type: "int", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roleOfUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleOfUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Consommation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock = table.Column<int>(type: "int", nullable: false),
                    qteUtilise = table.Column<int>(type: "int", nullable: false),
                    qteRestant = table.Column<int>(type: "int", nullable: false),
                    categorieOfConsommationategoryid = table.Column<int>(type: "int", nullable: false),
                    categorieOfConsommationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consommation_categorieOfConsommation_categorieOfConsommationid",
                        column: x => x.categorieOfConsommationid,
                        principalTable: "categorieOfConsommation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleOfUserid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    etat = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roleOfUsers_roleOfUserid",
                        column: x => x.roleOfUserid,
                        principalTable: "roleOfUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "production",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    effectifDepart = table.Column<int>(type: "int", nullable: false),
                    effectifFin = table.Column<int>(type: "int", nullable: false),
                    poids = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    consommationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production", x => x.id);
                    table.ForeignKey(
                        name: "FK_production_Consommation_consommationid",
                        column: x => x.consommationid,
                        principalTable: "Consommation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "observation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionid = table.Column<int>(type: "int", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_observation", x => x.id);
                    table.ForeignKey(
                        name: "FK_observation_production_productionid",
                        column: x => x.productionid,
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traitement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionid = table.Column<int>(type: "int", nullable: false),
                    archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traitement", x => x.id);
                    table.ForeignKey(
                        name: "FK_traitement_production_productionid",
                        column: x => x.productionid,
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consommation_categorieOfConsommationid",
                table: "Consommation",
                column: "categorieOfConsommationid");

            migrationBuilder.CreateIndex(
                name: "IX_observation_productionid",
                table: "observation",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "IX_production_consommationid",
                table: "production",
                column: "consommationid");

            migrationBuilder.CreateIndex(
                name: "IX_traitement_productionid",
                table: "traitement",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleOfUserid",
                table: "users",
                column: "roleOfUserid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "materiels");

            migrationBuilder.DropTable(
                name: "observation");

            migrationBuilder.DropTable(
                name: "traitement");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "production");

            migrationBuilder.DropTable(
                name: "roleOfUsers");

            migrationBuilder.DropTable(
                name: "Consommation");

            migrationBuilder.DropTable(
                name: "categorieOfConsommation");
        }
    }
}
