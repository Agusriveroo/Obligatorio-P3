using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.Enum;
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

        public EnvioController(ICUObtenerAgencias cUObteneragencias, ICUAltaEnvio cUAltaEnvio, ICUListarEnvios cUListarEnvios, ICUObtenerEnvio cUObtenerEnvio, ICUEditarEnvio cUEditarEnvio)
        {
            _cUObteneragencias = cUObteneragencias;
            _cUAltaEnvio = cUAltaEnvio;
            _cUListarEnvios = cUListarEnvios;
            _cUObtenerEnvio = cUObtenerEnvio;
            _cUEditarEnvio = cUEditarEnvio;
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

                if (vm.Dto.LogueadoId == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }

      

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
            dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
            _cUEditarEnvio.EditarEnvio(dto);
            return RedirectToAction("Index","Envio");
        }
    }
}
