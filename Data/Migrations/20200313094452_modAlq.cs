using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministarRenta.Data.Migrations
{
    public partial class modAlq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alquilado_CasaId",
                table: "Alquilado",
                column: "CasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquilado_Casa_CasaId",
                table: "Alquilado",
                column: "CasaId",
                principalTable: "Casa",
                principalColumn: "CasaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquilado_Casa_CasaId",
                table: "Alquilado");

            migrationBuilder.DropIndex(
                name: "IX_Alquilado_CasaId",
                table: "Alquilado");
        }
    }
}
