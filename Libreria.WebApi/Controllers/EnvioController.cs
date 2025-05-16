using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
   
        private ICUObtenerEnvioPorTracking _cUObtenerEnvioPorTracking;


        public EnvioController(ICUObtenerEnvioPorTracking cUObtenerEnvioPorTracking)
        {
           
      
            _cUObtenerEnvioPorTracking = cUObtenerEnvioPorTracking;

        }

        [HttpGet("{numTracking}")]
        public IActionResult GetByTracking(string numTracking)
        {
            try
            {
                DTOEnvioConDetalles envio = _cUObtenerEnvioPorTracking.ObtenerPorTracking(numTracking);


                if (string.IsNullOrWhiteSpace(numTracking))
                {
                    return BadRequest("Debe ingresar un número de tracking.");
                }

               
                if (envio == null)
                {
                    return NotFound($"No se encontró un envío con el número de tracking '{numTracking}'.");
                }


                return Ok(envio);
            }
            catch 
            {
                return StatusCode(500, "Error inesperado, intente más tarde");
            }
        }

    }
}
