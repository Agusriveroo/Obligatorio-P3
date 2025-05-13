using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class EmpleadoAuthorize: ActionFilterAttribute
    {


        public class AdminAuhorize : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var rol = context.HttpContext.Session.GetString("LogueadoRol");

                if (rol != "Administrador" && rol != "Funcionario")
                {
                    context.Result = new RedirectToActionResult("AccesoDenegado", "Usuario", null);
                }
                base.OnActionExecuting(context);
            }
        }

       
    }
   
    
}
