using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class ProblemasController : Controller
    {
        // GET: Problemas
        public ActionResult SearchProblemas()
        {
            return View();
        }
        public ActionResult Especifico(Buscar model)
        {
            List<Especifico> lst = null;
            using (var db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Ticket
                       join b in db.Solucion
                       on d.ID_Ticket equals b.ID_Ticket
                       join c in db.Pantallas
                       on d.ID_Pantalla equals c.ID_Pantalla
                       where d.Nombre_Problema.Contains(model.Nombre_Problema)

                       select new Especifico
                       {
                           Nombre_Problema = d.Nombre_Problema,
                           descripción_problema = d.Descripcion_Problema,
                           descrpcion_solucion = b.Descripcion_en_Pasos,
                           idpantalla = d.ID_Pantalla,
                           nombre_pantalla = c.Nombre_Pantalla
                       }).ToList();

            }
            return View(lst);
        }

        public ActionResult SeeProblemas()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;

            List<SeeProblema> lst = null;
            using (var db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Ticket
                       join b in db.Solucion
                       on d.ID_Ticket equals b.ID_Ticket
                       join c in db.Pantallas 
                       on d.ID_Pantalla equals c.ID_Pantalla
                      

                       select new SeeProblema
                       {
                           Nombre_Problema = d.Nombre_Problema,
                           descripción_problema = d.Descripcion_Problema,
                           descrpcion_solucion = b.Descripcion_en_Pasos,
                           idpantalla = d.ID_Pantalla,
                           nombre_pantalla= c.Nombre_Pantalla
                       }).ToList();

            }
            return View(lst);
        }
    }
}