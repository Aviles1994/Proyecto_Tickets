﻿using Proyecto_Tickets.Models.TableViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models.Viewslist;
using Proyecto_Tickets.Models.ViewsModels;
using Proyecto_Tickets.Models;
using System.Collections;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using System.IO;

namespace Proyecto_Tickets.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Add_Ticket()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarListaServicios();
            llenarListaMedioContacto();
            llenarCliente();


            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                List<Sistema> sistemalist = db.Sistema.ToList();
                ViewBag.sistemalist = new SelectList(sistemalist, "ID_Sistema", "Nombre_Sistema");

            }

            return View();
        }

        [HttpPost]
        public ActionResult Add_Ticket(AddTicketsViewModel model)
        {
            string Ruta;
            string PathImagen;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                if (model.Evidencia != null)
                {
                     Ruta= Server.MapPath("~/");
                     PathImagen= Path.Combine(Ruta + "/Evidencias/" + model.Evidencia.FileName);
                     model.Evidencia.SaveAs(PathImagen);
                }
                else
                {
                     PathImagen = null;
                }
                
                Ticket oticket = new Ticket();
                oticket.Fecha_Hora_Inicio = DateTime.Now;
                oticket.Version_Usuario = model.versionUser;
                oticket.Nombre_Problema =model.nombreProblema;
                oticket.Descripcion_Problema = model.descrpcionProblema;
                oticket.ID_Pantalla = model.ID_Pantalla;
                oticket.ID_Usuario_Cliente =model.ID_usuarioCliente;
                oticket.ID_Medio_de_Contacto = model.ID_MedioContacto;
                oticket.ID_Servicio =model.ID_Servico;
                oticket.ID_Estado = 1;
                oticket.ID_Prioridad = 2;

                oticket.Imagen = PathImagen;

                try
                {
                    db.Ticket.Add(oticket);
                    db.SaveChanges();

                    TicketsVarViemModel.idTickets =  oticket.ID_Ticket;

                }
                catch (Exception ex)
                {
                    return Content("noo" + ex.InnerException);
                }

              
            }
            

            using ( var db= new Sistema_TicketsEntities())
            {
                Historial_Ticket ohistorial_ticket = new Historial_Ticket();
                ohistorial_ticket.Accion_Realizada = "Se registro";
                ohistorial_ticket.ID_Estado = 1;
                ohistorial_ticket.Fecha_Hora_Modificacion = DateTime.Now;
                ohistorial_ticket.ID_Estratei = UserSession.iduser;
                ohistorial_ticket.ID_Ticket = TicketsVarViemModel.idTickets;

                db.Historial_Ticket.Add(ohistorial_ticket);
                db.SaveChanges();
            }
            return Content("1");
        }
        public ActionResult AddSolucion()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
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
                    return Content("nooo"+ ex.InnerException);
                }
            }
            using (var db = new Sistema_TicketsEntities())
            {
                Historial_Ticket ohistorial_ticket = new Historial_Ticket();
                ohistorial_ticket.Accion_Realizada = "Se agrego solución";
                ohistorial_ticket.ID_Estado = 3;
                ohistorial_ticket.Fecha_Hora_Modificacion = DateTime.Now;
                ohistorial_ticket.ID_Estratei = UserSession.iduser;
                ohistorial_ticket.ID_Ticket = TicketsVarViemModel.idTickets;

                db.Historial_Ticket.Add(ohistorial_ticket);
                db.SaveChanges();


                var oticket = db.Ticket.Find(TicketsVarViemModel.idTickets);
                oticket.ID_Estado = 3;
                oticket.Fecha_Hora_Fin = DateTime.Now;
                db.Entry(oticket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            return Content("1");
        }


        public ActionResult SeeTicketsCliente(ElegidoTickets model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;

            List<SeeTicketsUsuarios> lst = null;
            using ( var db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Ticket
                       join c in db.Pantallas on d.ID_Pantalla equals c.ID_Pantalla
                       join w in db.Medio_de_Contacto on d.ID_Medio_de_Contacto equals w.ID_Medio_de_Contacto
                       join f in db.Estado on d.ID_Estado equals f.ID_Estado
                       join a in db.Prioridad on d.ID_Prioridad equals a.ID_Prioridad
                       join r in db.Servicio on d.ID_Servicio equals r.ID_Servicio
                       where d.ID_Usuario_Cliente == model.ID_usuarioCliente 

                       select new SeeTicketsUsuarios
                       {
                           idTicket = d.ID_Ticket,
                           fecha_inicio = d.Fecha_Hora_Inicio,
                           version_usuario = d.Version_Usuario,
                           nombre_problema = d.Nombre_Problema,
                           descripción_problema = d.Descripcion_Problema,

                           idpantalla=d.ID_Pantalla,
                           Nombre_Pantalla=c.Nombre_Pantalla,
                           
                           idmedio_contacto =d.ID_Medio_de_Contacto,
                           Nombre_MedioContacto=w.Nombre_Medio_de_Contacto,

                           idestado=d.ID_Estado,
                           Nombre_Estado=f.Nombre_Estado,

                           idprioridad=d.ID_Prioridad,
                           Nombre_Prioridad=a.Nombre_Prioridad,

                           idservicio=d.ID_Servicio,
                           Nombre_Servicio=r.Nombre_Servicio


                       }).ToList();
            }

                return View(lst);
            

        }

        public ActionResult SeeTicketsPendientes()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;

            List<SeeTicketsPendientes> lst = null;
            using (var db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Ticket
                       join c in db.Pantallas on d.ID_Pantalla equals c.ID_Pantalla
                       join w in db.Medio_de_Contacto on d.ID_Medio_de_Contacto equals w.ID_Medio_de_Contacto
                       join f in db.Estado on d.ID_Estado equals f.ID_Estado
                       join a in db.Prioridad on d.ID_Prioridad equals a.ID_Prioridad
                       join r in db.Servicio on d.ID_Servicio equals r.ID_Servicio
                       join g in db.Usuario_Cliente on d.ID_Usuario_Cliente equals g.ID_Usuario_Cliente
                       where d.ID_Estado != 3 

                       select new SeeTicketsPendientes
                       {
                           idTicket = d.ID_Ticket,
                           version_usuario = d.Version_Usuario,
                           nombre_problema = d.Nombre_Problema,
                           descripción_problema = d.Descripcion_Problema,

                           idusuario=d.ID_Usuario_Cliente,
                           Nombre_Usuario=g.Nombre_UCliente,

                           idpantalla = d.ID_Pantalla,
                           Nombre_Pantalla = c.Nombre_Pantalla,

                           idmedio_contacto = d.ID_Medio_de_Contacto,
                           Nombre_MedioContacto = w.Nombre_Medio_de_Contacto,

                           idestado = d.ID_Estado,
                           Nombre_Estado = f.Nombre_Estado,

                           idprioridad = d.ID_Prioridad,
                           Nombre_Prioridad = a.Nombre_Prioridad,

                           idservicio = d.ID_Servicio,
                           Nombre_Servicio = r.Nombre_Servicio
                       }).ToList();
            }

            return View(lst);
            
        }
        public ActionResult SeeTicketsNumero(ElegidoTickets model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;

            List<SeeTicketsNumero> lst = null;
            using (var db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Ticket
                       join c in db.Pantallas on d.ID_Pantalla equals c.ID_Pantalla
                       join w in db.Medio_de_Contacto on d.ID_Medio_de_Contacto equals w.ID_Medio_de_Contacto
                       join f in db.Estado on d.ID_Estado equals f.ID_Estado
                       join a in db.Prioridad on d.ID_Prioridad equals a.ID_Prioridad
                       join r in db.Servicio on d.ID_Servicio equals r.ID_Servicio
                       join g in db.Usuario_Cliente on d.ID_Usuario_Cliente equals g.ID_Usuario_Cliente
                       where d.ID_Ticket ==model.ID_Ticket

                       select new SeeTicketsNumero
                       {
                           idTicket = d.ID_Ticket,
                           fecha_inicio = d.Fecha_Hora_Inicio,
                           version_usuario = d.Version_Usuario,
                           nombre_problema = d.Nombre_Problema,
                           descripción_problema = d.Descripcion_Problema,

                           idusuario = d.ID_Usuario_Cliente,
                           Nombre_Usuario = g.Nombre_UCliente,

                           idpantalla = d.ID_Pantalla,
                           Nombre_Pantalla = c.Nombre_Pantalla,

                           idmedio_contacto = d.ID_Medio_de_Contacto,
                           Nombre_MedioContacto = w.Nombre_Medio_de_Contacto,

                           idestado = d.ID_Estado,
                           Nombre_Estado = f.Nombre_Estado,

                           idprioridad = d.ID_Prioridad,
                           Nombre_Prioridad = a.Nombre_Prioridad,

                           idservicio = d.ID_Servicio,
                           Nombre_Servicio = r.Nombre_Servicio

                       }).ToList();
            }

            return View(lst);

        }
        public JsonResult GetCliente(int ID_Cliente)
        {
            List<Usuario_Cliente> userlist = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                userlist = db.Usuario_Cliente.Where(x => x.ID_Cliente == ID_Cliente & x.Estatus==true).ToList();
                
            }

            List<SelectListItem> items_C = userlist.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_UCliente.ToString(),
                    Value = d.ID_Usuario_Cliente.ToString(),
                    Selected = false
                };
            }).ToList();

                return Json(userlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSistema(int ID_Sistema)
        {
            List<Modulos> moduloslist = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                moduloslist = db.Modulos.Where(x => x.ID_Sistema == ID_Sistema).ToList();

            }

            List<SelectListItem> items_C = moduloslist.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_Modulo.ToString(),
                    Value = d.ID_Modulo.ToString(),
                    Selected = false
                };
            }).ToList();

            return Json(moduloslist, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult GetModulo(int ID_Modulo)
        {
            List<Pantallas> pantallaslist = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                pantallaslist = db.Pantallas.Where(x => x.ID_Modulo == ID_Modulo).ToList();

            }

            List<SelectListItem> items_C = pantallaslist.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_Pantalla.ToString(),
                    Value = d.ID_Pantalla.ToString(),
                    Selected = false
                };
            }).ToList();

            return Json(pantallaslist, JsonRequestBehavior.AllowGet);
            
        }

        

        public ActionResult SearchTickets()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarCliente();
            return View();
        }

        public void llenarCliente()
        {
            List<listCliente> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Cliente
                   select new listCliente
                   {
                       id = d.ID_Cliente,
                       name = d.Nombre_Cliente
                   }).ToList();
            }
            List<SelectListItem> items_Cli = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.name.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_Cli = items_Cli;
        }


        public void llenarListaMedioContacto()
        {
            List<listMedioContacto> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Medio_de_Contacto
                   select new listMedioContacto
                   {
                       idmedio = d.ID_Medio_de_Contacto,
                       namemedio = d.Nombre_Medio_de_Contacto
                   }).ToList();
            }
            List<SelectListItem> items_MC = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.namemedio.ToString(),
                    Value = d.idmedio.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_MC = items_MC;
        }

        public void llenarListaServicios()
        {
            List<listServico> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Servicio
                   select new listServico
                   {
                       idservicio = d.ID_Servicio,
                       nameservicio = d.Nombre_Servicio
                   }).ToList();
            }
            List<SelectListItem> items_S = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nameservicio.ToString(),
                    Value = d.idservicio.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_S = items_S;
        }

    }
}