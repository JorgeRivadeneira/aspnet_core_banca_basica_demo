using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Rol es Obligatorio")]
        [StringLength(20)]
        [Display(Name = "Rol de Usuario")]
        public String RolUsuario { get; set; }

        [Required(ErrorMessage = "El Login es Obligatorio")]
        [StringLength(20)]
        [Display(Name = "Login de Usuario")]
        public String UserLogin { get; set; }

        [Required(ErrorMessage = "El Password es Obligatorio")]
        [StringLength(20)]
        [Display(Name = "Password del Usuario")]
        public String UserPassword { get; set; }
    }
}
