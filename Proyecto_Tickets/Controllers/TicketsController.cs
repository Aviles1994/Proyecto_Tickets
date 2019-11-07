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
        public ActionResult Add_Ticket(AddTicketsViewModel model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarListaMedioContacto();
            llenarListaServicios();
            llenarListaCliente();

            return View();
        }

        public ActionResult SearchTickets()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
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
        public void llenarListaCliente()
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
                    Value = d.name.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_Cli = items_Cli;
        }

        [HttpGet]
        public JsonResult UsuarioCliente(int idCliente)
        {
            List<ElementJasonIintKey> lst = new List<ElementJasonIintKey>();
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst = (from d in db.Usuario_Cliente
                       where d.ID_Cliente == idCliente
                       select new ElementJasonIintKey
                       {
                           value = d.ID_Usuario_Cliente,
                           Text = d.Nombre_UCliente
                       }).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public class ElementJasonIintKey
        {
            public int value { get; set; }
            public string Text{ get; set; }
        }





    }
}