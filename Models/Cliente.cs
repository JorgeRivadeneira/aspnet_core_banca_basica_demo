using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancaBasica.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 20)]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "La Direccion es obligatoria")]
        [StringLength(100)]
        [Display(Name = "Direccion del Domicilio")]
        public String Direccion { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(20)]
        [Display(Name = "Telefono del Cliente")]
        public String Telefono { get; set; }
    }
}
