using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Domicilio
    {
        [Display(Name = "DomicilioID")]
        public int DomicilioID { get; set; }

        [Display(Name = "Nombre")]
        public int TransporteID { get; set; }
        public Transporte Transporte { get; set; }
        public DateTime HoraFecha { get; set; }
    }
}
