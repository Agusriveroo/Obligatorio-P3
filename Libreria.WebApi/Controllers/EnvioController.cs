using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
   
        private ICUObtenerEnvioPorTracking _cUObtenerEnvioPorTracking;
        private ICUObtenerEnviosCliente _cUObtenerEnviosCliente;
        private ICUObtenerDetalles _cUObtenerDetalles;
        private ICUObtenerEnvio _cUObtenerEnvio;


        public EnvioController(ICUObtenerEnvioPorTracking cUObtenerEnvioPorTracking, ICUObtenerEnviosCliente cUObtenerEnviosCliente, ICUObtenerDetalles cUObtenerDetalles,ICUObtenerEnvio cUObtenerEnvio)
        {
           
      
            _cUObtenerEnvioPorTracking = cUObtenerEnvioPorTracking;
            _cUObtenerEnviosCliente = cUObtenerEnviosCliente;
            _cUObtenerDetalles = cUObtenerDetalles;
            _cUObtenerEnvio = cUObtenerEnvio;

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

        [HttpGet("misenvios")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosDeUsuario() 
        {
            string email = EmailUsuarioLogueado();
            try
            {
                List<DTOListarEnvio> enviosCliente = _cUObtenerEnviosCliente.Ejecutar(email);
                return Ok(enviosCliente);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        private string EmailUsuarioLogueado() 
        {
            string email = null;

            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null) 
            { 
                var emailClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;

        }

        [HttpGet("detalles/{id}")]
        [Authorize(Roles = "Cliente")]
        public IActionResult ObtenerEnvioConDetalles(int id)
        {
            var envio = _cUObtenerEnvio.ObtenerEnvio(id);
            if (envio == null)
                return NotFound($"No se encontró un envío con ID {id}");

            var detalles = _cUObtenerDetalles.ObtenerDetalles(id); 

            var envioConDetalles = new DTOEnvioConDetalles
            {
                NumeroTracking = envio.NumeroTracking,
                EmailCliente = envio.EmailCliente,
                PesoPaquete = envio.PesoPaquete,
                Estado = envio.Estado,
                Detalles = detalles.Select(d => new DTODetallesParaEnvios
                {
                    Comentario = d.Comentario,
                    Fecha = d.Fecha,
                 
                }).ToList()
            };

            return Ok(envioConDetalles);
        }

    }
}
