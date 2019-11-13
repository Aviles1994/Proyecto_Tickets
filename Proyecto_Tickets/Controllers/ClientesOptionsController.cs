using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;
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
        public ActionResult AddUsuario(AddUsuariosClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Usuarios_Login UserL = new Usuarios_Login();
            model.ULUltimoLogin = DateTime.Now;
            using (var db = new Sistema_TicketsEntities())
            {
                
                UserL.Nombre_Usuarios_Login = model.ULnombre;
                UserL.Contraseña = model.ULcontraseña;
                UserL.Estatus = model.ULestatus;
                UserL.Ultimo_Login = model.ULUltimoLogin;
                UserL.Correo_electronico = model.ULCcorreo_electronico;
                UserL.ID_Tipo_Usuario = 2;

                db.Usuarios_Login.Add(UserL);
                db.SaveChanges();

                UserLogin.id_User = UserL.ID_Usuarios_Login;
            }


            using (var dbc = new Sistema_TicketsEntities())
            {
                Usuario_Cliente UC = new Usuario_Cliente();
                UC.Nombre_UCliente = model.UCnombre;
                UC.Apellido_PaternoUCliente = model.UCapellidoP;
                UC.Apellido_MaternoUCliente = model.UCapellidoM;
                UC.Usuario_Clave = model.UcusuarioClave;
                UC.Celular = model.UCcelular;
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
                    return Content("Ocurrio un error" + ex.Message);
                }
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
                       where d.ID_Cliente == model.idCliente

                       select new SeeUsuariosClienteTableViewModel
                       {
                           iduserC = d.ID_Usuario_Cliente,
                           NombreC = d.Nombre_UCliente,
                           ApellidoP = d.Apellido_PaternoUCliente,
                           ApellidoM = d.Apellido_MaternoUCliente,
                           UseClave = d.Usuario_Clave,
                           Celular = d.Celular,
                           TelOfi = d.Telefono_Oficina,
                           Extencion = d.Extension,
                           idCliente = d.ID_Cliente,
                           iduser = d.ID_Usuarios_Login
                       }).ToList();

            }
            return View(lst);

        }





    }
}