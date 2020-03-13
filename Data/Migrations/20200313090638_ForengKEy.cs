using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministarRenta.Data.Migrations
{
    public partial class ForengKEy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Casa_ResponsableId",
                table: "Casa",
                column: "ResponsableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Responsable");
        }
    }
}
