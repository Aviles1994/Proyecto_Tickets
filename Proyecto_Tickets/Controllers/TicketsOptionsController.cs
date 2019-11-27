﻿using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using Proyecto_Tickets.Models.Viewslist;
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
        public ActionResult EditEstado(int id)
        {
            llenarEstado();
            EditEstado model = new EditEstado();
            using (var db = new Sistema_TicketsEntities())
            {
                var oticket = db.Ticket.Find(id);
                model.nombreProblema = oticket.Nombre_Problema;
                model.descrpcionProblema = oticket.Descripcion_Problema;
                model.idEstado = oticket.ID_Estado;
                model.idTicket = oticket.ID_Ticket;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult EditEstado(EditEstado model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                
                var oticket = db.Ticket.Find(model.idTicket);
                
                if (oticket.ID_Estado == 2 || oticket.ID_Estado == 3)
                {
                    oticket.ID_Estado = model.idEstado;
                    oticket.Fecha_Hora_Fin = DateTime.Now;
                    db.Entry(oticket).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    cambioEstado.idEstado = model.idEstado;
                }
                else if (oticket.ID_Estado != model.idEstado)
                {
                    oticket.ID_Estado = model.idEstado;
                    db.Entry(oticket).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    cambioEstado.idEstado = model.idEstado;
                }

            }

            using (var db = new Sistema_TicketsEntities())
            {
                Historial_Ticket ohistorial_ticket = new Historial_Ticket();
                ohistorial_ticket.Accion_Realizada = "Se cambio el estado";
                ohistorial_ticket.ID_Estado = cambioEstado.idEstado ;
                ohistorial_ticket.Fecha_Hora_Modificacion = DateTime.Now;
                ohistorial_ticket.ID_Estratei = UserSession.iduser;
                ohistorial_ticket.ID_Ticket = model.idTicket;

                db.Historial_Ticket.Add(ohistorial_ticket);
                db.SaveChanges();
            }
            return Content("1");
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

        public void llenarEstado()
        {
            List<ListEstado> lst= null;
            using (var db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Estado
                   select new ListEstado
                   {
                       ID_Estado = d.ID_Estado,
                       Nombre_Estado = d.Nombre_Estado
                   }).ToList();
            }
            List<SelectListItem> items_estado = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_Estado.ToString(),
                    Value = d.ID_Estado.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_estado = items_estado;
        }
    }
}