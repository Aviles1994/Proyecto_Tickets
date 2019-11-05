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

        public ActionResult BuscarCliente()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarlistaCliente();

            List<ClienteExpecificoTableViewModel> lst = null;
            using (var dbs = new Sistema_TicketsEntities())
            {
                ObtenerClienteTableViewModel ele = new ObtenerClienteTableViewModel();
                lst = (from d in dbs.Cliente
                       where d.Nombre_Cliente == ele.namecliente

                       select new ClienteExpecificoTableViewModel
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

        public ActionResult VerClientes()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;


            List<ClientesTableViewModel> lst = null;
            using (var dbc = new Sistema_TicketsEntities())
            {
                lst = (from d in dbc.Cliente
                       orderby d.ID_Cliente
                       select new ClientesTableViewModel
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
            List<ObtenerClienteTableViewModel> lstt = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lstt =
                  (from d in db.Cliente
                   select new ObtenerClienteTableViewModel
                   {
                       id = d.ID_Cliente,
                       namecliente = d.Nombre_Cliente
                   }).ToList();
            }
            List<SelectListItem> items = lstt.ConvertAll(d =>
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