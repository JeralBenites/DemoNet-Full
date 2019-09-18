using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SolIntermedio.ClienteMVC.Models
{
    public class ValidaPermiso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) &&
                 !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {

                bool valida = ValidaIngreso(filterContext);
                if (!valida)
                {
                    Redirecciona(filterContext);
                }
            }
            base.OnActionExecuting(filterContext);
        }

        private void Redirecciona(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                    { "controller", "Home" },
                    { "action", "NoAutorizado"}

                });
        }

        private bool ValidaIngreso(
            ActionExecutingContext filterContext)
        {
            //Valido si tienes la cookie y estas autenticado
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                return false;
            }

            if (HttpContext.Current.Session["Opciones"] == null)
            {
                return false;
            }

            var routeoData =
                RouteTable.Routes.GetRouteData(filterContext.HttpContext);
            string controladora = (string)routeoData.Values["controller"];
            string accion = (string)routeoData.Values["action"];

            List<Opcion> opciones = 
                (List<Opcion>)HttpContext.Current.Session["Opciones"];

            Opcion opcion = (from x in opciones
                             where x.Controladora.ToLower() == controladora.ToLower()
                             && x.Accion.ToLower() == accion.ToLower()
                             && !string.IsNullOrEmpty(x.Controladora)
                             && !string.IsNullOrEmpty(x.Accion)
                             select x).FirstOrDefault();

            return opcion != null;
        }
    }
}