using Libreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AltaUsuarioViewModel
    {

        public DTOAltaUsuario DtoUsuario { get; set; }
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}
