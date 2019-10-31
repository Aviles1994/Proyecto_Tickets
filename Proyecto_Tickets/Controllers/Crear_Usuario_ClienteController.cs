using Proyecto_Tickets.Models.TableViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class Crear_Usuario_ClienteController : Controller
    {
        // GET: Crear_Usuario_Cliente
        public ActionResult Crear_Usuario_Cliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }


    }
}