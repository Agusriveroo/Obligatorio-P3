using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ICUCambiarPassword _cuCambiarPassword;

        public UsuarioController(ICUCambiarPassword cUCambiarPassword)
        {
            _cuCambiarPassword = cUCambiarPassword;
        }

        private int ObtenerIdUsuarioLogueado()
        {
            int id = 0;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var idClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (idClaim != null)
                {
                    id = int.Parse(idClaim.Value);
                }
            }
            return id;
        }


        [HttpGet("cambiarContraseña")]
        [Authorize(Roles = "Cliente")]
        public IActionResult CambiarPassword()
        {
            return Ok();
        }

        [HttpPost("cambiarContraseña")]
        [Authorize(Roles = "Cliente")]
        public IActionResult CambiarPassword(string cActual, string cNueva)
        {
            int logId = ObtenerIdUsuarioLogueado();

            if (string.IsNullOrEmpty(cActual) || string.IsNullOrEmpty(cNueva)) 
            {
                return BadRequest("Debe ingresar la contraseña actual y la nueva.");
            }

            try
            {
                _cuCambiarPassword.Ejecutar(logId, cActual, cNueva);
                return Ok("Contraseña cambiada correctamente");
            }
            catch (PasswordIncorrectaException)
            {
                return BadRequest("La contraseña actual es incorrecta");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado, intente más tarde");


            }
        }
    }


}
