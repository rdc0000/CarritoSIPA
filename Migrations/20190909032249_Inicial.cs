using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrito.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticuloID);
                });

            migrationBuilder.CreateTable(
                name: "Autoservicio",
                columns: table => new
                {
                    AutoservicioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoservicio", x => x.AutoservicioID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Documento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    NumeroReferencia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoID);
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    TransporteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoVehiculo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.TransporteID);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    DetallePedidoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticuloID = table.Column<int>(nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    PrecioTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.DetallePedidoID);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Articulo_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransporteID = table.Column<int>(nullable: false),
                    HoraFecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.DomicilioID);
                    table.ForeignKey(
                        name: "FK_Domicilio_Transporte_TransporteID",
                        column: x => x.TransporteID,
                        principalTable: "Transporte",
                        principalColumn: "TransporteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoservicioID = table.Column<int>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false),
                    MetodoPagoID = table.Column<int>(nullable: false),
                    DomicilioID = table.Column<int>(nullable: false),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoID);
                    table.ForeignKey(
                        name: "FK_Pedido_Autoservicio_AutoservicioID",
                        column: x => x.AutoservicioID,
                        principalTable: "Autoservicio",
                        principalColumn: "AutoservicioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "DomicilioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_MetodoPago_MetodoPagoID",
                        column: x => x.MetodoPagoID,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ArticuloID",
                table: "DetallePedido",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_TransporteID",
                table: "Domicilio",
                column: "TransporteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_AutoservicioID",
                table: "Pedido",
                column: "AutoservicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteID",
                table: "Pedido",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DomicilioID",
                table: "Pedido",
                column: "DomicilioID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_MetodoPagoID",
                table: "Pedido",
                column: "MetodoPagoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Autoservicio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Transporte");
        }
    }
}
