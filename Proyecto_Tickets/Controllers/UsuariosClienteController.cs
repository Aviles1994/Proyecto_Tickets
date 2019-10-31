using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class UsuariosClienteController : Controller
    {
        // GET: UsuariosCliente
        public ActionResult AddUsuario()
        {
            return View();
        }
    }
}