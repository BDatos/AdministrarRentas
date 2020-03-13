using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministarRenta.Data.Migrations
{
    public partial class newproyect : Migration
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
                name: "Huesped",
                columns: table => new
                {
                    HuespedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    NombreAereolin = table.Column<string>(nullable: true),
                    HoraDeLlegada = table.Column<DateTime>(nullable: false),
                    CantAcompañantes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.HuespedId);
                });

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    ResponsableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.ResponsableId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioID);
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

            migrationBuilder.CreateTable(
                name: "Alquilado",
                columns: table => new
                {
                    FechaEntrada = table.Column<DateTime>(nullable: false),
                    HuespedId = table.Column<int>(nullable: false),
                    CasaId = table.Column<int>(nullable: false),
                    ReservacionDias = table.Column<int>(nullable: false),
                    Valores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquilado", x => x.FechaEntrada);
                    table.ForeignKey(
                        name: "FK_Alquilado_Huesped_HuespedId",
                        column: x => x.HuespedId,
                        principalTable: "Huesped",
                        principalColumn: "HuespedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    CasaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: false),
                    Cantidad_Cuartos = table.Column<int>(nullable: false),
                    Cantida_WC = table.Column<int>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ServicioPrestado",
                columns: table => new
                {
                    ServiciosPrestadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HuespedId = table.Column<int>(nullable: false),
                    ServiciosId = table.Column<int>(nullable: false),
                    Resumen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioPrestado", x => x.ServiciosPrestadoId);
                    table.ForeignKey(
                        name: "FK_ServicioPrestado_Huesped_HuespedId",
                        column: x => x.HuespedId,
                        principalTable: "Huesped",
                        principalColumn: "HuespedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioPrestado_Servicios_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itinerario",
                columns: table => new
                {
                    FechaRecogida = table.Column<DateTime>(nullable: false),
                    TaxiId = table.Column<int>(nullable: true),
                    HuespedId = table.Column<int>(nullable: false),
                    CantidasDeDias = table.Column<int>(nullable: false),
                    Jefe = table.Column<string>(nullable: false),
                    Recorrido = table.Column<string>(nullable: false),
                    Resumen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerario", x => x.FechaRecogida);
                    table.ForeignKey(
                        name: "FK_Itinerario_Huesped_HuespedId",
                        column: x => x.HuespedId,
                        principalTable: "Huesped",
                        principalColumn: "HuespedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itinerario_Taxi_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxi",
                        principalColumn: "TaxiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquilado_HuespedId",
                table: "Alquilado",
                column: "HuespedId");

            migrationBuilder.CreateIndex(
                name: "IX_Casa_ResponsableId",
                table: "Casa",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerario_HuespedId",
                table: "Itinerario",
                column: "HuespedId");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerario_TaxiId",
                table: "Itinerario",
                column: "TaxiId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioPrestado_HuespedId",
                table: "ServicioPrestado",
                column: "HuespedId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioPrestado_ServiciosId",
                table: "ServicioPrestado",
                column: "ServiciosId");

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
                name: "Alquilado");

            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Itinerario");

            migrationBuilder.DropTable(
                name: "ServicioPrestado");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "Taxi");

            migrationBuilder.DropTable(
                name: "Huesped");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Chofer");
        }
    }
}
