using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministarRenta.Data.Migrations
{
    public partial class muchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Matricula = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: true),
                    capacidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Chofer",
                columns: table => new
                {
                    CI = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chofer", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    TaxiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoferId = table.Column<int>(nullable: false),
                    CarroId = table.Column<string>(nullable: true),
                    Deudas = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Taxi_CarroId",
                table: "Taxi",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxi_ChoferId",
                table: "Taxi",
                column: "ChoferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxi");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Chofer");
        }
    }
}
