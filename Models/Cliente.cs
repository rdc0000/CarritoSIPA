using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Cliente
    {
        public int ClienteID{ get; set; }
        [Required(ErrorMessage="Campo obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los nombres tiene que tener de minimo 3" +
            " a 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los apellidos tiene que tener de minimo 3" +
            " a 50 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Documento { get; set; }
    }
}
