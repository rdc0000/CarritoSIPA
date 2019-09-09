using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Carrito.Models;

    public class CarritoContext : DbContext
    {
    public CarritoContext()
    {
    }

    public CarritoContext (DbContextOptions<CarritoContext> options)
            : base(options)
        {
        }

        public DbSet<Carrito.Models.Articulo> Articulo { get; set; }

        public DbSet<Carrito.Models.DetallePedido> DetallePedido { get; set; }

        public DbSet<Carrito.Models.Cliente> Cliente { get; set; }

        public DbSet<Carrito.Models.Autoservicio> Autoservicio { get; set; }

        public DbSet<Carrito.Models.MetodoPago> MetodoPago { get; set; }

        public DbSet<Carrito.Models.Domicilio> Domicilio { get; set; }

        public DbSet<Carrito.Models.Pedido> Pedido { get; set; }

        public DbSet<Carrito.Models.Transporte> Transporte { get; set; }
}
