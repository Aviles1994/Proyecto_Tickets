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

        public JsonResult GetCliente(int ID_Cliente)
        {

            List<listUserCliente> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                lst =
                  (from d in db.Usuario_Cliente
                   where d.ID_Cliente==ID_Cliente
                   select new listUserCliente
                   {
                       idUserCliente= d.ID_Usuario_Cliente,
                       nameUserCliente = d.Nombre_UCliente
                   }).ToList();
            }
            List<SelectListItem> items_UC = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nameUserCliente.ToString(),
                    Value = d.idUserCliente.ToString(),
                    Selected = false
                };

            });
            return Json(items_UC, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSistema(int ID_Sistema)
        {

            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Modulos> moduloslist = db.Modulos.Where(x => x.ID_Sistema == ID_Sistema).ToList();
                return Json(moduloslist, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GetModulo(int ID_Modulo)
        {

            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Pantallas> pantallalist = db.Pantallas.Where(x => x.ID_Modulo == ID_Modulo).ToList();
                return Json(pantallalist, JsonRequestBehavior.AllowGet);

            }
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