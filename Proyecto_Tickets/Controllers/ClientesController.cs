using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.ViewsModels;
using Proyecto_Tickets.Models.TableViewsModels;
namespace Proyecto_Tickets.Controllers
{
    public class ClientesController : Controller
    {

        public ActionResult AddCliente() {
            ViewData["nombre_user"] = UserSession.nombre_user;
            List<listEntidadFederativa> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Entidad_Federativa
                   select new listEntidadFederativa
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
        public ActionResult AddCliente(AddClientesViewsModel model)
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



                try
                {
                    db.Cliente.Add(clientes);
                    db.SaveChanges();
                    Clientes.idCliente = clientes.ID_Cliente;

                }
                catch (Exception ex)
                {
                    return Content("Ocurrio un error" + ex.Message);
                }
            }


            return Content("1");

        }

        public ActionResult SearchCliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarlistaCliente();

            List<SearchClienteTableViewModel> lst = null;
            using (var dbs = new Sistema_TicketsEntities())
            {
                listCliente list_name = new listCliente();
                lst = (from d in dbs.Cliente
                       where d.Nombre_Cliente == list_name.namecliente

                       select new SearchClienteTableViewModel
                       {
                           idCliente = d.ID_Cliente,
                           NameCliente = d.Nombre_Cliente,
                           Calle = d.Calle,
                           numero = d.Numero,
                           colonia = d.Colonia,
                           telefono = d.Telefono,
                           correo_electronico = d.Correo_Electronico,
                           etidad_feerativa = d.ID_Entidad_Federativa
                       }).ToList();
                return View(lst);
            }
 
        }

        public ActionResult SeeClientes()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;


            List<SeeClientesTableViewModel> lst = null;
            using (var dbc = new Sistema_TicketsEntities())
            {
                lst = (from d in dbc.Cliente
                       orderby d.ID_Cliente
                       select new SeeClientesTableViewModel
                       {
                           idCliente = d.ID_Cliente,
                           NameCliente = d.Nombre_Cliente,
                           Calle = d.Calle,
                           numero = d.Numero,
                           colonia = d.Colonia,
                           telefono = d.Telefono,
                           correo_electronico = d.Correo_Electronico,
                           etidad_feerativa = d.ID_Entidad_Federativa
                       }).ToList();

            }
            return View(lst);
        }

        public void llenarlistaCliente()
        {
            List<listCliente> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Cliente
                   select new listCliente
                   {
                       id = d.ID_Cliente,
                       namecliente = d.Nombre_Cliente
                   }).ToList();
            }
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.namecliente.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };

            });
            ViewBag.items = items;
        }

    }
}