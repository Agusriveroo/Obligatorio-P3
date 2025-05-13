using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Filtros;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUListarEmpleados _CUListarEmpleados;
        private ICUObtenerRolesEmpleados _cuObtenerRoles;
        private ICULogin _cuLogin;
        private ICUObtenerUsuario _cuObtenerUsuario;
        private ICUActualizarUsuario _CUActualizarUsuario;
        private ICUDeleteUsuario CUDeleteUsuario;
        private ICUDetalleUsuario _cuDetalleUsuario;


        public UsuarioController(ICUAltaUsuario CUAltaUsuario, ICUListarEmpleados CUListarEmpleados, ICUObtenerRolesEmpleados cuObtenerRoles, ICULogin cULogin, ICUObtenerUsuario cuObtenerUsuario, ICUActualizarUsuario cUActualizarUsuario, ICUDeleteUsuario cUDeleteUsuario, ICUDetalleUsuario cUDetalleUsuario)
        {
            _CUAltaUsuario = CUAltaUsuario;
            _CUListarEmpleados = CUListarEmpleados;
            _cuObtenerRoles = cuObtenerRoles;
            _cuLogin = cULogin;
            _cuObtenerUsuario = cuObtenerUsuario;
            _CUActualizarUsuario = cUActualizarUsuario;
            CUDeleteUsuario = cUDeleteUsuario;
            _cuDetalleUsuario = cUDetalleUsuario;
        }
        public IActionResult Index()
        {
            
        
            List<DTOListarEmpleado> listaEmpleados = _CUListarEmpleados.ListarEmpleados();

            return View(listaEmpleados);
        }


        [LogueadoAuthorize]
        [EmpleadoAuthorize]
        public IActionResult Create() {

        
            List<DTORol> roles = _cuObtenerRoles.Obtener();
            AltaUsuarioViewModel m = new AltaUsuarioViewModel();

            foreach (var r in roles) 
            {
                SelectListItem item = new SelectListItem();
                item.Text = r.Nombre;
                item.Value = r.Id.ToString();
                m.Roles.Add(item);
            }
             


            return View(m);  
        
        }

        [HttpPost]
        public IActionResult Create(AltaUsuarioViewModel vm)
        {

            try
            {
                int? loggId = HttpContext.Session.GetInt32("LogueadoId");
                vm.DtoUsuario.LogueadoId = loggId; 
                _CUAltaUsuario.AltaEmpleado(vm.DtoUsuario);
                ViewBag.msg = "Usuario creado correctamente";
            }
            catch (NombreUsuarioException e)
            {
                ViewBag.msg = e.Message;
            }
            catch (EdadMinimaException e)
            {
                ViewBag.msg = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            return View(vm);

        }


        public IActionResult Login() 
        {
            /* DATOS LOGIN: ADMIN -> agustinri2011@hotmail.com
                                     abc1234 
                            FUN -> sfernandez@gmail.com
                                    ejemplo1234567
            */

            return View();
        }


        [HttpPost]
        public IActionResult Login(DTOUsuario dto)
        {

            try
            {
                
                DTOUsuario b =  _cuLogin.VerificarDatos(dto);

                HttpContext.Session.SetInt32("LogueadoId", (int)b.Id);
                HttpContext.Session.SetString("LogueadoRol", b.Rol.ToString());
                HttpContext.Session.SetString("NombreUsuario", b.Nombre);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                throw;

            }

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login", "Usuario");
        }





        public IActionResult Edit(int id) 
        {
            DTOUsuario model = _cuObtenerUsuario.ObtenerUsuario(id);
            return View(model);
        
        }

        [HttpPost]
        public IActionResult Edit(DTOUsuario dto)
        {

            try
            {
                dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _CUActualizarUsuario.ActualizarUsuario(dto);

            }
            catch (EdadMinimaException e)
            {

                ViewBag.error = e.Message;
            }
            catch (NombreUsuarioException e)
            {

                ViewBag.error = e.Message;
            }
            catch (Exception e)
            {

                ViewBag.error = e.Message;

            }


            return View();

        }


        public IActionResult Delete(int id)
        {
            DTOUsuario model = _cuObtenerUsuario.ObtenerUsuario(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(DTOUsuario model)
        {
            int? loggId = HttpContext.Session.GetInt32("LogueadoId");

            if (loggId == null)
                return RedirectToAction("Login", "Usuario");

            try
            {
                CUDeleteUsuario.Delete(model.Id);
                TempData["msg"] = "Usuario eliminado correctamente";
            }
            catch (Exception e)
            {
                TempData["msg"] = "Error al eliminar usuario: " + e.Message;
            }

            return RedirectToAction("Index", "Usuario");
        }



        public IActionResult Details(int id) 
        {

            DTOUsuario usuario = _cuDetalleUsuario.ObtenerDetalles(id, (int)HttpContext.Session.GetInt32("LogueadoId"));

            if (usuario == null)
            {
                return RedirectToAction("Index","Home");
            }

            return View(usuario);
        }

     




        public IActionResult AccesoDenegado() 
        {
            return View();
        }


    }
}
