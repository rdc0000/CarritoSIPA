﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carrito.Migrations
{
    [DbContext(typeof(CarritoContext))]
    partial class CarritoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Carrito.Models.Articulo", b =>
                {
                    b.Property<int>("ArticuloID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<string>("Imagen");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.HasKey("ArticuloID");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("Carrito.Models.DetallePedido", b =>
                {
                    b.Property<int>("DetallePedidoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticuloID");

                    b.Property<int>("Cantidad");

                    b.Property<decimal>("PrecioTotal");

                    b.Property<decimal>("Total");

                    b.HasKey("DetallePedidoID");

                    b.HasIndex("ArticuloID");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("Carrito.Models.DetallePedido", b =>
                {
                    b.HasOne("Carrito.Models.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloID");
                });
#pragma warning restore 612, 618
        }
    }
}
