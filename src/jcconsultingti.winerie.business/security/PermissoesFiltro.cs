using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace jcconsultingti.winerie.business.security
{
    public class PermissoesFiltro : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //Caso usuario esteja deslogado
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.HttpContext.Response.Redirect("~/Login");

            //Caso o usuario nao foi autorizado, ele sera enviado para pagina de acesso negado
            else if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("~/Login/AcessoNegado");
        }
    }
}
