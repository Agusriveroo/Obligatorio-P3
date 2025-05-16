using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filtros
{
    public class GerenteAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("LogueadoRol");

            if (rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("AccesoDenegado", "Usuario", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
