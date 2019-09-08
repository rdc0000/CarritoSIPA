using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class MetodoPago
    {
        public int MetodoPagoID { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string NumeroReferencia { get; set; }
    }
}
