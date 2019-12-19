using Proyecto_Tickets.Models;
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
    public class ClientesOptionsController : Controller
    {
        // GET: ClientesOptions

        [HttpGet]
        public ActionResult AddUsuario(SeeUsuariosClienteTableViewModel model)
        {
            Clientes.idCliente = model.idCliente;
            

            return View();

        }

        [HttpPost]
        public ActionResult AddUsuario(AddUsuariosOptionsClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                Usuarios_Login UL = new Usuarios_Login();
                UL.Nombre_Usuarios_Login = model.ULnombre;
                UL.Contraseña = model.ULcontraseña;
                UL.Estatus = model.ULestatus;
                UL.Ultimo_Login = DateTime.Now;
                UL.Correo_electronico = model.ULCcorreo_electronico;
                UL.ID_Tipo_Usuario = 2;

                try
                {
                    db.Usuarios_Login.Add(UL);
                    db.SaveChanges();
                    UserLogin.id_User = UL.ID_Usuarios_Login;
                }
                catch (Exception ex)
                {
                    return Content("Error" + ex.InnerException);
                }

            }

            using (var dbc = new Sistema_TicketsEntities())
            {
                Usuario_Cliente UC = new Usuario_Cliente();
                UC.Nombre_UCliente = model.UCnombre;
                UC.Apellido_PaternoUCliente = model.UCapellidoP;
                UC.Apellido_MaternoUCliente = model.UCapellidoM;
                UC.Usuario_Clave = model.UcusuarioClave;
                UC.Celular = model.UCcelular;
                UC.Estatus = true;
                UC.Telefono_Oficina = model.UctelOf;
                UC.Extension = model.UCext;
                UC.ID_Cliente = Clientes.idCliente;
                UC.ID_Usuarios_Login = UserLogin.id_User;

                try
                {
                    dbc.Usuario_Cliente.Add(UC);
                    dbc.SaveChanges();

                }
                catch (Exception ex)
                {
                    return Content("Los datos son incorrectos" + ex.Message);
                }

                return Content("1");
            }
        }

        
        public ActionResult EditCliente(int id)
        {
            llenarEntidadFedarativa();
       
            EditClientesViewModel model = new EditClientesViewModel();
            using (var db = new Sistema_TicketsEntities())
            {
                var oCliente = db.Cliente.Find(id);
                model.Nombre_Cliente = oCliente.Nombre_Cliente;
                model.Calle = oCliente.Calle;
                model.Numero = oCliente.Numero;
                model.Colonia = oCliente.Colonia;
                model.Telefono = oCliente.Telefono;
                model.Correo_Electronico = oCliente.Correo_Electronico;
                model.ID_EF = oCliente.ID_Entidad_Federativa;
                model.id_c = oCliente.ID_Cliente;

            }
                return View(model);
        }


        [HttpPost]
        public ActionResult EditCliente(EditClientesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                var oCliente = db.Cliente.Find(model.id_c);
                oCliente.Nombre_Cliente = model.Nombre_Cliente;
                oCliente.Calle = model.Calle;
                oCliente.Numero = model.Numero;
                oCliente.Colonia = model.Colonia;
                oCliente.Telefono = model.Telefono;
                oCliente.Correo_Electronico = model.Correo_Electronico;
                oCliente.ID_Entidad_Federativa = model.ID_EF;
               
                db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
                return Content("1");

        }


        [HttpGet]
        public ActionResult SeeUsuario(SeeUsuariosClienteTableViewModel model)
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            List<SeeUsuariosClienteTableViewModel> lst = null;
            using (var dbc = new Sistema_TicketsEntities())
            {
                lst = (from d in dbc.Usuario_Cliente
                       where d.ID_Cliente == model.idCliente & d.Estatus==true 


                       select new SeeUsuariosClienteTableViewModel
                       {
                           iduserC = d.ID_Usuario_Cliente,
                           NombreC = d.Nombre_UCliente,
                           ApellidoP = d.Apellido_PaternoUCliente,
                           ApellidoM = d.Apellido_MaternoUCliente,
                           UseClave = d.Usuario_Clave,
                           Celular = d.Celular,
                           TelOfi = d.Telefono_Oficina,
                           Extencion = (int) d.Extension,
                           idCliente = d.ID_Cliente,
                           iduser = d.ID_Usuarios_Login
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