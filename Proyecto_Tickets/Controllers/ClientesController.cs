using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.Viewslist;
using Proyecto_Tickets.Models.ViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
using Proyecto_Tickets.Models.TableViewsModels;
namespace Proyecto_Tickets.Controllers
{
    public class ClientesController : Controller
    {

        public ActionResult AddCliente() {
            ViewData["nombre_user"] = UserSession.nombre_user;
            llenarEntidadFedarativa();
            llenarSistema();
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
                clientes.ID_Entidad_Federativa = model.ID_EF;
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

            using (var dbSistema = new Sistema_TicketsEntities())
            {
                Sistema_Cliente sis_Cliente = new Sistema_Cliente();
                sis_Cliente.ID_Sistema = model.ID_Sistema;
                sis_Cliente.ID_Cliente = Clientes.idCliente;
                sis_Cliente.Version_Cliente = model.version_sis;
                sis_Cliente.Vigencia = model.vigencia;
                sis_Cliente.Fecha_Contrato = model.fecha_contrato;

                dbSistema.Sistema_Cliente.Add(sis_Cliente);
                dbSistema.SaveChanges();

            }
        return Content("1");

        }

        
        public ActionResult SelecSearchCliente()
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
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.name.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };

            });
            ViewBag.items = items;
            return View();
        }

        public ActionResult SearchCliente(ClientesVarViewsModel model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;

            List<SearchClienteTableViewModel> lst;
            using (var dbs = new Sistema_TicketsEntities())
            {
                
                lst = (from d in dbs.Cliente
                       where d.ID_Cliente == model.idcliente

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


        public void llenarEntidadFedarativa()
        {
            List<listEntidadFederativa> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Entidad_Federativa
                   select new listEntidadFederativa
                   {
                       id_EF = d.ID_Entidad_Federativa,
                       name_EF = d.Nombre_Entidad_Federativa
                   }).ToList();
            }
            List<SelectListItem> items_EF = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.name_EF.ToString(),
                    Value = d.id_EF.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_EF = items_EF;
        }

        public void llenarSistema()
        {
            List<lisSistema> lst = null;
            using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
            {
                lst =
                  (from d in db.Sistema
                   select new lisSistema
                   {
                       id_Sistema = d.ID_Sistema,
                       name_Sistema = d.Nombre_Sistema
                   }).ToList();
            }
            List<SelectListItem> items_Sis = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.name_Sistema.ToString(),
                    Value = d.id_Sistema.ToString(),
                    Selected = false
                };

            });
            ViewBag.items_Sis = items_Sis;
        }



    }
}