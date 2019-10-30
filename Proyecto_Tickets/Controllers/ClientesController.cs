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
            return View();
        }
    }
}