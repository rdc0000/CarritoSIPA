using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrito.Migrations
{
    public partial class Proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorID",
                table: "Articulo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_ProveedorID",
                table: "Articulo",
                column: "ProveedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Proveedor_ProveedorID",
                table: "Articulo",
                column: "ProveedorID",
                principalTable: "Proveedor",
                principalColumn: "ProveedorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Proveedor_ProveedorID",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_ProveedorID",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "ProveedorID",
                table: "Articulo");
        }
    }
}
