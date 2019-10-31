using Proyecto_Tickets.Models.TableViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.ViewsModels;

namespace Proyecto_Tickets.Controllers
{
    public class ClientesController : Controller
    {
        int respuesta = 0;   
        public ActionResult CrearCliente() {
            ViewData["nombre_user"] = UserSession.nombre_user;
            List<Entidad_federativaViewModel> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Entidad_Federativa
                   select new Entidad_federativaViewModel
                   {
                       ID_Entidad = d.ID_Entidad_Federativa,
                       Nombre = d.Nombre_Entidad_Federativa

                   }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.ID_Entidad.ToString(),
                    Selected = false
                };

            });




            ViewBag.items = items;

            return View();
        }

       [HttpPost]
        public ActionResult CrearCliente(ClientesViewsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Sistema_TicketsEntities())
            {
                Cliente clientes = new Cliente();
                clientes.Nombre_Cliente = model.Nombre_Cliente;
                clientes.Calle = model.Calle;
                clientes.Numero = model.Numero;
                clientes.Colonia = model.Colonia;
                clientes.Telefono = model.Telefono;
                clientes.Correo_Electronico = model.Correo_Electronico;
                clientes.ID_Entidad_Federativa = model.ID_Entidad_Federativa;

                db.Cliente.Add(clientes);
                db.SaveChanges();
            }

            respuesta = 1;
            if (respuesta == 1) {
                return Content("1");
            }
            return View();

    }

        public ActionResult BuscarCliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }

        public ActionResult VerClientes()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }
    }
}