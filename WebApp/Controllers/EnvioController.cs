using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EnvioController : Controller
    {

        private ICUObtenerAgencias _cUObteneragencias;
        private ICUAltaEnvio _cUAltaEnvio;
        private ICUListarEnvios _cUListarEnvios;
        private ICUObtenerEnvio _cUObtenerEnvio;
        private ICUEditarEnvio _cUEditarEnvio;
        private ICUAgregarComentario _cUAgregarComentario;  
        private ICUObtenerDetalles _cUObtenerDetalles;


        public EnvioController(ICUObtenerAgencias cUObteneragencias, ICUAltaEnvio cUAltaEnvio, ICUListarEnvios cUListarEnvios, ICUObtenerEnvio cUObtenerEnvio, ICUEditarEnvio cUEditarEnvio, ICUAgregarComentario cUAgregarComentario, ICUObtenerDetalles cUObtenerDetalles)
        {
            _cUObteneragencias = cUObteneragencias;
            _cUAltaEnvio = cUAltaEnvio;
            _cUListarEnvios = cUListarEnvios;
            _cUObtenerEnvio = cUObtenerEnvio;
            _cUEditarEnvio = cUEditarEnvio;
            _cUAgregarComentario = cUAgregarComentario;
            _cUObtenerDetalles = cUObtenerDetalles;

        }

        public IActionResult Index()
        {
            List<DTOListarEnvio> listaEnvios = _cUListarEnvios.ListarEnvios();

            return View(listaEnvios);
        }
        
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach (var a in _cUObteneragencias.ObtenerAgencias()) 
            {
                SelectListItem item = new SelectListItem();
                item.Text = a.Nombre;   
                item.Value = a.Id.ToString();   
                vm.Agencias.Add(item);

            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                vm.Dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");

                // if (vm.Dto.LogueadoId == null)
                //{
                //  return RedirectToAction("Login", "Usuario");
                //}
                // Si el cliente no está logueado, no asignamos un LogueadoId.

                _cUAltaEnvio.AltaEnvio(vm.Dto);

                ViewBag.msg = "Registro correcto";
                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                ViewBag.msg = "No se pudo registrar: " + ex.Message;
            
                return View(vm);
            }

        }

        public IActionResult Edit(int id)
        {
            DTOListarEnvio model = _cUObtenerEnvio.ObtenerEnvio(id);
            ViewBag.FinalizadoValor = (int)EstadoEnvio.FINALIZADO;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DTOListarEnvio dto)
        {
            try
            {
                dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _cUEditarEnvio.EditarEnvio(dto);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo editar el envío: " + ex.Message;
                return View(dto);
            }
        }


        public IActionResult Detalle(int id)
        {
            int? logueadoId = HttpContext.Session.GetInt32("LogueadoId");

            try
            {
                var envio = _cUObtenerEnvio.ObtenerEnvio(id);

                if (envio == null)
                {
                    TempData["Error"] = "No se encontró el envío.";
                    return RedirectToAction("Index");
                }

                var nuevoDetalle = new DTODetalle
                {
                    EnvioId = envio.IdEnvio,
                    Fecha = DateTime.Now,
                    LogueadoId = logueadoId,
                };

                var detalles = _cUObtenerDetalles.ObtenerDetalles(id);
                detalles.Add(nuevoDetalle);

                return View(detalles);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No se pudo preparar el formulario: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Detalle(int EnvioId, string Comentario)
        {
            int? logueadoId = HttpContext.Session.GetInt32("LogueadoId");

            try
            {
                _cUAgregarComentario.AgregarComentario(EnvioId, logueadoId, Comentario);
                Console.WriteLine("Completado correctamente");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
                ViewBag.Error = "No se pudo agregar el comentario: " + ex.Message;
                Console.WriteLine(ViewBag.Error);
                return RedirectToAction("Index");
            }
        }

    }
}
