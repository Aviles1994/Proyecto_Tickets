using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ViewData["nombre_user"] = UserSession.nombre_user;
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
                           idSolucion = b.ID_Solucion,
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

        public ActionResult VerMasProblema(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new Sistema_TicketsEntities();
            VerMasProblema oVerMas = new VerMasProblema();

            var solucion = db.Solucion.Find(id);
            oVerMas.Descripcion_Solucion = solucion.Descripcion_en_Pasos;
            oVerMas.Fecha_Solucion = solucion.Fecha_Solucion;

            var ticket = db.Ticket.Find(solucion.ID_Ticket);
            oVerMas.fecha_hora_Inicio = ticket.Fecha_Hora_Inicio;
            oVerMas.versionUser = ticket.Version_Usuario;
            oVerMas.nombreProblema = ticket.Nombre_Problema;
            oVerMas.descrpcionProblema = ticket.Descripcion_Problema;
            oVerMas.fecha_hora_Fin = (DateTime)ticket.Fecha_Hora_Fin;

            var Pantalla = db.Pantallas.Find(ticket.ID_Pantalla);
            oVerMas.Nombre_Pantalla = Pantalla.Nombre_Pantalla;

            var NombreUsuarioCliente = db.Usuario_Cliente.Find(ticket.ID_Usuario_Cliente);
            oVerMas.Nombre_Usuario_Cliente = NombreUsuarioCliente.Nombre_UCliente;

            var MedioContacto = db.Medio_de_Contacto.Find(ticket.ID_Medio_de_Contacto);
            oVerMas.Nombre_Medio_Contacto = MedioContacto.Nombre_Medio_de_Contacto;

            var Servicio = db.Servicio.Find(ticket.ID_Servicio);
            oVerMas.Nombre_Servicio = Servicio.Nombre_Servicio;

            var Estado = db.Estado.Find(ticket.ID_Estado);
            oVerMas.Nombre_Estado = Estado.Nombre_Estado;

            var Prioridad = db.Prioridad.Find(ticket.ID_Prioridad);
            oVerMas.Nombre_Prioridad = Prioridad.Nombre_Prioridad;

            var PersonalEstratei = db.Personal_Estratei.Find(solucion.ID_Estratei);
            oVerMas.Nombre_Personal = PersonalEstratei.Nombre_PEstratei;
            oVerMas.ApellidoP_Personal = PersonalEstratei.Apellido_PaternoPEstratei;
            oVerMas.ApellidoM_Personal = PersonalEstratei.Apellido_MaternoPEstratei;
            oVerMas.Celular = PersonalEstratei.Celular;
            oVerMas.Puesto = PersonalEstratei.Puesto;
            

            if (solucion == null)
            {
                return HttpNotFound();
            }

            return View(oVerMas);

        }
    }
}