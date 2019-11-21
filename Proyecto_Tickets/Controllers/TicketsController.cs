using Proyecto_Tickets.Models.TableViewsModels;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                Ticket oticket = new Ticket();
                oticket.Fecha_Hora_Inicio = DateTime.Now;
                oticket.Version_Usuario = model.versionUser;
                oticket.Nombre_Problema =model.nombreProblema;
                oticket.Descripcion_Problema = model.descrpcionProblema;
                oticket.ID_Pantalla = model.ID_Pantalla;
                oticket.ID_Usuario_Cliente =model.ID_cliente;
                oticket.ID_Medio_de_Contacto = model.ID_MedioContacto;
                oticket.ID_Servicio =model.ID_Servico;
                oticket.ID_Estado = 1;
                oticket.ID_Prioridad = 2;

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

                return Content("1");
            }
        }
        public ActionResult AddSolucion()
        {
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
                oSolucion.ID_Estratei =UserSession.iduser;

                try
                {
                    db.Solucion.Add(oSolucion);
                    db.SaveChanges();

                }catch (Exception ex)
                {
                    return Content("nooo"+ ex.InnerException);
                }
            }
                return Content("1");
        }

        public JsonResult GetCliente(int ID_Cliente)
        {
            List<Usuario_Cliente> userlist = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                userlist = db.Usuario_Cliente.Where(x => x.ID_Cliente == ID_Cliente).ToList();
                
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
                       namemedio = d.Nombre_MedioC
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