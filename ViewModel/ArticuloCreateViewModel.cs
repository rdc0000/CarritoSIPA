using Carrito.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.ViewModel
{
    public class ArticuloCreateViewModel
    {
        public Proveedor Proveedor { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
