﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carrito.Migrations
{
    [DbContext(typeof(CarritoContext))]
    [Migration("20190909032249_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("Cantidad");

                    b.Property<string>("Imagen");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.HasKey("ArticuloID");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("Carrito.Models.Autoservicio", b =>
                {
                    b.Property<int>("AutoservicioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<bool>("Estado");

                    b.Property<string>("Imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("AutoservicioID");

                    b.ToTable("Autoservicio");
                });

            modelBuilder.Entity("Carrito.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<string>("Documento")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("ClienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Carrito.Models.DetallePedido", b =>
                {
                    b.Property<int>("DetallePedidoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticuloID");

                    b.Property<decimal>("Cantidad");

                    b.Property<decimal>("PrecioTotal");

                    b.Property<decimal>("Total");

                    b.HasKey("DetallePedidoID");

                    b.HasIndex("ArticuloID");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("Carrito.Models.Domicilio", b =>
                {
                    b.Property<int>("DomicilioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoraFecha");

                    b.Property<int>("TransporteID");

                    b.HasKey("DomicilioID");

                    b.HasIndex("TransporteID");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("Carrito.Models.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("NumeroReferencia")
                        .IsRequired();

                    b.HasKey("MetodoPagoID");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("Carrito.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutoservicioID");

                    b.Property<int>("ClienteID");

                    b.Property<string>("Direccion");

                    b.Property<int>("DomicilioID");

                    b.Property<DateTime>("FechaHora");

                    b.Property<int>("MetodoPagoID");

                    b.Property<int>("Total");

                    b.HasKey("PedidoID");

                    b.HasIndex("AutoservicioID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("DomicilioID");

                    b.HasIndex("MetodoPagoID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Carrito.Models.Transporte", b =>
                {
                    b.Property<int>("TransporteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<bool>("Estado");

                    b.Property<string>("Marca");

                    b.Property<string>("Placa");

                    b.Property<string>("TipoVehiculo");

                    b.HasKey("TransporteID");

                    b.ToTable("Transporte");
                });

            modelBuilder.Entity("Carrito.Models.DetallePedido", b =>
                {
                    b.HasOne("Carrito.Models.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloID");
                });

            modelBuilder.Entity("Carrito.Models.Domicilio", b =>
                {
                    b.HasOne("Carrito.Models.Transporte", "Transporte")
                        .WithMany()
                        .HasForeignKey("TransporteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carrito.Models.Pedido", b =>
                {
                    b.HasOne("Carrito.Models.Autoservicio", "Autoservicio")
                        .WithMany()
                        .HasForeignKey("AutoservicioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carrito.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carrito.Models.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carrito.Models.MetodoPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
