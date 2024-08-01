using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinalGourmetGrill.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProductos",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProductos", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    ITBS = table.Column<float>(type: "real", nullable: false),
                    Recibido = table.Column<float>(type: "real", nullable: false),
                    Devuelta = table.Column<float>(type: "real", nullable: false),
                    Eliminada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    ITBIS = table.Column<float>(type: "real", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriaProductos_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaProductos",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    OrdenesDetalleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenesDetalleId",
                        column: x => x.OrdenesDetalleId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId");
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    DetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.DetalleID);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriaProductos",
                columns: new[] { "CategoriaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hamburguesas" },
                    { 2, "Papas" },
                    { 3, "Acompañantes" },
                    { 4, "Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "NombreEstado" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Preparando" },
                    { 3, "YA ESTÁ LISTA" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPagos",
                columns: new[] { "MetodoPagoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Cantidad", "CategoriaId", "Descripcion", "Disponible", "ITBIS", "ImagenUrl", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 50, 1, "Pan de Papa, Doble Carne de 95g, Doble Queso Pepper Jack, Mermelada de Arandanos, Pesto y Aderezo de Perejil", true, 85.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/UltimateCrackBurger.jpg", "La Intensa", 475f },
                    { 2, 50, 1, "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon y Crema de Hongos Trufada", true, 90f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/PizzaBurger.jpg", "Funghi Girl", 500f },
                    { 3, 50, 1, "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Bacon, Pulled Pork con Salsa BBQ y Coleslaw", true, 72f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Formula.jpg", "La Formula", 450f },
                    { 4, 50, 1, "Pan de Brioche, Doble Carne de 95g, Doble Queso Americano, Bacon y Aderezo Spread", true, 58.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/ClassicBacon.jpg", "Clasic Bacon", 325f },
                    { 5, 50, 1, "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Cebolla Smashed y Alioli de Ajo", true, 76.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Oklahoma.jpg", "Oklahoma", 425f },
                    { 6, 50, 1, "Pan Brioche de Molde, Pechuga Empanizada, Doble Queso Americano, Bacon, Miel y Spicy Mayo", true, 72f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/KitchenBurguer.jpg", "Kitchen Little", 400f },
                    { 7, 50, 1, "Pan de Papa, Doble Carne de 95g, Doble Queso Americano, Mermelada de Bacon, Aros de Cebolla Empanizadas y BBQ", true, 90f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/CheeseBurguer.jpg", "Baby Q", 500f },
                    { 8, 50, 2, "Papas Fritas, Fondue de Queso Cheddar, Puerro y Bacon Bites", true, 63f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BaconFries.jpg", "Bacon Cheese Fries", 350f },
                    { 9, 50, 2, "Papas Fritas, Chilli, Fondue de Queso Cheddar y Alioli de Ajo", true, 67.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/ChiliFries.jpg", "Chilli Fries", 375f },
                    { 10, 50, 2, "Papas Fritas, Birria, Alioli de Ajo y Doble Queso Pepper Jack", true, 90f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BirriaFries.jpg", "Birria Fries", 500f },
                    { 11, 50, 3, "Papas Fritas", true, 9f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Fries.jpg", "Papas Fritas", 50f },
                    { 12, 50, 3, "Papas Enteras con Su piel cortadas Por La Mitad y Sazonadas con Ajo, Sal y Pimienta", true, 25.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/PotatoWedges.jpg", "Papas Wedges", 125f },
                    { 13, 50, 3, "5 Cebollas Fritas", true, 13.5f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/FriedOnion.jpg", "Aros de Cebolla", 75f },
                    { 14, 50, 4, "Botella de Agua Fria", true, 3.6f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/BottleWaterjpg.jpg", "Agua", 20f },
                    { 15, 50, 4, "Coca Cola 500ml de Cristal", true, 9f, "https://stgourmetgrilldv001.blob.core.windows.net/gourmetweb/Cocacola.jpg", "Coca Cola 500ml ", 50f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenesDetalleId",
                table: "OrdenesDetalle",
                column: "OrdenesDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ProductoId",
                table: "OrdenesDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_ProductoId",
                table: "VentasDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "CategoriaProductos");
        }
    }
}
