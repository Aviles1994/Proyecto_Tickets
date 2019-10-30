using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
using Proyecto_Tickets.Controllers;


namespace Proyecto_Tickets.Firters
{
    public class VerifySession : ActionFilterAttribute 
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user = (Usuarios_Login)HttpContext.Current.Session["user"];

            if (user == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Login");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Clientes/CrearCliente");
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}