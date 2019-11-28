using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult logoff()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}