using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Articulo
    {
        public int ArticuloID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public string Imagen{ get; set; }
    }
}
