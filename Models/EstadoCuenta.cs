using System;
using System.ComponentModel.DataAnnotations;


namespace BancaBasica.Models
{
    public class EstadoCuenta
    {

        [Required(ErrorMessage = "Fecha Inicio es Obligatoria")]
        [Display(Name = "Seleccione una fecha inicial")]
        public DateTime FechaIni { get; set; }

        [Required(ErrorMessage = "Fecha Fin es Obligatoria")]
        [Display(Name = "Seleccione una fecha final")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El Cliente es Obligatorio")]
        [Display(Name = "Seleccione un Cliente")]
        public int Id_Cliente { get; set; }
    }
}
