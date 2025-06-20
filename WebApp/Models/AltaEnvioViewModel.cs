using Libreria.DTOs.DTOs.DTOsEnvio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AltaEnvioViewModel
    {
        public DTOAltaEnvio Dto { get; set; }

        public List<SelectListItem> TiposEnvios { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "comun", Text = "Comun" },
        new SelectListItem { Value = "urgente", Text = "Urgente" }
    };

        public List<SelectListItem> Agencias { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Clientes { get; set; } = new List<SelectListItem>();
    }
}
