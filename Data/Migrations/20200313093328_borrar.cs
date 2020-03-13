using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministarRenta.Data.Migrations
{
    public partial class borrar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Huésped");

            migrationBuilder.DropTable(
                name: "Taxi");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Chofer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Matricula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Chofer",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chofer", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Huésped",
                columns: table => new
                {
                    HuespedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantAcompañantes = table.Column<int>(type: "int", nullable: false),
                    HoraDeLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAereolin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huésped", x => x.HuespedId);
                });

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.ResponsableId);
                });

            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    TaxiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChoferId = table.Column<int>(type: "int", nullable: false),
                    Deudas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.TaxiId);
                    table.ForeignKey(
                        name: "FK_Taxi_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taxi_Chofer_ChoferId",
                        column: x => x.ChoferId,
                        principalTable: "Chofer",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    CasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantida_WC = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Cuartos = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsableId = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.CasaId);
                    table.ForeignKey(
                        name: "FK_Casa_Responsable_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Responsable",
                        principalColumn: "ResponsableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casa_ResponsableId",
                table: "Casa",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxi_CarroId",
                table: "Taxi",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxi_ChoferId",
                table: "Taxi",
                column: "ChoferId");
        }
    }
}
