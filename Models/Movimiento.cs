using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BancaBasica.Models
{
    public class Movimiento
    {
        [Key]
        public int Id_Movimiento { get; set; } //Numero de movimiento

        //Foreign key for Cuenta
        [Required(ErrorMessage = "La cuenta del cliente es obligatorio")]
        [Display(Name = "Cuenta del Cliente")]
        public int Id_Cuenta { get; set; }

        [Required(ErrorMessage = "El Valor de la Transaccion es obligatorio")]
        [Display(Name = "Valor de la Transaccion")]
        public double Valor { get; set; }

        [Display(Name = "Fecha de la Transaccion")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El Tipo de Transaccion es obligatorio")]
        [Display(Name = "Tipo de Transaccion")]
        public String Tipo { get; set; }
    }
}
