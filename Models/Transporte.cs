using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Transporte
    {
        public int TransporteID { get; set; }
        public string TipoVehiculo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public Boolean Estado { get; set; }
    }
}
