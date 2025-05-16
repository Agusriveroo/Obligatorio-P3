using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsUsuario
{
    public class DTOAltaUsuario
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(18, 120, ErrorMessage = "La edad debe ser mayor o igual a 18")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un rol")]
        public string Rol { get; set; }


        public int? LogueadoId { get; set; }
    }

}
