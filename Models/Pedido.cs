using Carrito.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Pedido
    {
        [Display(Name = "PedidoID")]
        public int PedidoID { get; set; }
        
        [Display(Name = "Autoservicio")]
        public int AutoservicioID { get; set; }
        public Autoservicio Autoservicio { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "MetodoPago")]
        public int MetodoPagoID { get; set; }
        public MetodoPago MetodoPago { get; set; }

        [Display(Name = "Domicilio")]
        public int DomicilioID { get; set; }
        public Domicilio Domicilio { get; set; }

        public DateTime FechaHora { get; set; }
        public string Direccion { get; set; }
        public int Total { get; set; }


    }
}
