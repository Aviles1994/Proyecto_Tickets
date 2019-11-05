﻿using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;

namespace Proyecto_Tickets.Controllers
{
    public class UsuariosClienteController : Controller
    {
        // GET: UsuariosCliente
        public ActionResult AddUsuario()
        {
            ViewData["nombre_user"] = UserSession.nombre_user;
            return View();
        }


        [HttpPost]
        public ActionResult AddUsuario(AddUsuariosClienteViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Usuario_Cliente UC = new Usuario_Cliente();
            model.ULUltimoLogin = DateTime.Now;
            using (var db = new Sistema_TicketsEntities())
            {
                Usuarios_Login UL = new Usuarios_Login();
                UL.Nombre_Usuarios_Login = model.ULnombre;
                UL.Contraseña = model.ULcontraseña;
                UL.Estatus = model.ULestatus;
                UL.Ultimo_Login = model.ULUltimoLogin;
                UL.Correo_electronico = model.ULCcorreo_electronico;
                UL.ID_Tipo_Usuario = 2;

                db.Usuarios_Login.Add(UL);
                db.SaveChanges();
                UserLogin.id_User = UL.ID_Usuarios_Login;
            }


            using (var dbc = new Sistema_TicketsEntities())
            {
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
    }
}