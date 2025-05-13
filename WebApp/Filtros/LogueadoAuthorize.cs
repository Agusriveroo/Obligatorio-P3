using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Filtros
{
    public class LogueadoAuthorize: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logueadoId= context.HttpContext.Session.GetInt32("LogueadoId");

            if (logueadoId == null )
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }
            base.OnActionExecuting(context);
        }
    }
   
}
