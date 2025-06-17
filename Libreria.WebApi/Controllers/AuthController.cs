using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _cuLogin;
        
        public AuthController(ICULogin cULogin )
        {
     
            _cuLogin = cULogin;
         
        }

        [HttpPost]
        public IActionResult Login([FromBody] DtoLogin)
        {
            try
            {
                var usuario = _cuLogin.VerificarDatos(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
