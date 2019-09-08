using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Autoservicio
    {
        public int AutoservicioID { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3,ErrorMessage ="Nombre maximo de 50 caracteres y minimo de 3 caracteres")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        public Boolean Estado { get; set; }
        public string Imagen { get; set; }
    }
}
