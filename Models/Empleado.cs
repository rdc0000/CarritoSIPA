using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los nombres tiene que tener de minimo 3" +
            "a 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los apellidos tiene que tener de minimo 3" +
            "a 50 caracteres")]
        public string Apellido { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string Telefono { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int InputModelID { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Contraseña { get; set; }
        }
    }
}
