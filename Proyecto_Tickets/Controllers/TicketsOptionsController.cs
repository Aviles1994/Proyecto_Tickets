using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using Proyecto_Tickets.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class TicketsOptionsController : Controller
    {
        // GET: TicketsOptions
        public ActionResult EditTickets()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSolucion(SeeTicketsUsuarios model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            TicketsVarViemModel.idTickets = model.idTicket;

            return View();
        }

        [HttpPost]
        public ActionResult AddSolucion(AddSolucionViewModel model)
        {

            using (var db = new Sistema_TicketsEntities())
            {
                Solucion oSolucion = new Solucion();
                oSolucion.Descripcion_en_Pasos = model.Descripcion;
                oSolucion.Fecha_Solucion = model.fecha;
                oSolucion.ID_Ticket = TicketsVarViemModel.idTickets;
                oSolucion.ID_Estratei = UserSession.iduser;

                try
                {
                    db.Solucion.Add(oSolucion);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    return Content("nooo" + ex.InnerException);
                }
            }
            return Content("1");
        }
    }
}