using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.Data.Migrations
{
    public partial class MigrationVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    CodProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correlativo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Concentracion = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    Restriccion = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    CodDetVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.CodProducto);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Codventa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descuento = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteCodCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Codventa);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "Cliente",
                        principalColumn: "CodCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    CodDetVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    IGV = table.Column<double>(type: "float", nullable: false),
                    CodVenta = table.Column<int>(type: "int", nullable: false),
                    VentaCodventa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.CodDetVenta);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta_VentaCodventa",
                        column: x => x.VentaCodventa,
                        principalTable: "Venta",
                        principalColumn: "Codventa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentaProducto",
                columns: table => new
                {
                    DetalleVentaCodDetVenta = table.Column<int>(type: "int", nullable: false),
                    ProductoCodProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentaProducto", x => new { x.DetalleVentaCodDetVenta, x.ProductoCodProducto });
                    table.ForeignKey(
                        name: "FK_DetalleVentaProducto_DetalleVenta_DetalleVentaCodDetVenta",
                        column: x => x.DetalleVentaCodDetVenta,
                        principalTable: "DetalleVenta",
                        principalColumn: "CodDetVenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVentaProducto_Producto_ProductoCodProducto",
                        column: x => x.ProductoCodProducto,
                        principalTable: "Producto",
                        principalColumn: "CodProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaCodventa",
                table: "DetalleVenta",
                column: "VentaCodventa");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaProducto_ProductoCodProducto",
                table: "DetalleVentaProducto",
                column: "ProductoCodProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteCodCliente",
                table: "Venta",
                column: "ClienteCodCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVentaProducto");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
