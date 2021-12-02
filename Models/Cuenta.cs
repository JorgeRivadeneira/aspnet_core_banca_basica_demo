using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancaBasica.Models
{
    public class Cuenta
    {
        [Key]
        public int Id_Cuenta { get; set; } //Numero de cuenta

        //Foreign key for Client
        [Required(ErrorMessage = "El cliente es obligatorio")]
        [Display(Name = "Seleccione un cliente")]
        public int Id_Cliente { get; set; }

        [Required(ErrorMessage = "El saldo de la cuenta es obligatorio")]
        [Display(Name = "Saldo del Cliente")]
        public double Saldo { get; set; }
    }
}
