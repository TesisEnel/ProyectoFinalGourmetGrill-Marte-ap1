using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalGourmetGrill.Migrations
{
    /// <inheritdoc />
    public partial class Secundary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesDetalle_Ordenes_OrdenesDetalleId",
                table: "OrdenesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesDetalle_OrdenesDetalleId",
                table: "OrdenesDetalle");

            migrationBuilder.DropColumn(
                name: "OrdenesDetalleId",
                table: "OrdenesDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "OrdenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                table: "OrdenesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle");

            migrationBuilder.AddColumn<int>(
                name: "OrdenesDetalleId",
                table: "OrdenesDetalle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenesDetalleId",
                table: "OrdenesDetalle",
                column: "OrdenesDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesDetalle_Ordenes_OrdenesDetalleId",
                table: "OrdenesDetalle",
                column: "OrdenesDetalleId",
                principalTable: "Ordenes",
                principalColumn: "OrdenId");
        }
    }
}
