using Proyecto_Tickets.Models.TableViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult CrearCliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }

        public ActionResult BuscarCliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }

        public ActionResult VerClientes()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }
    }
}