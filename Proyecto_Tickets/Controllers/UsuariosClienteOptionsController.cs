using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class UsuariosClienteOptionsController : Controller
    {
        // GET: UsuariosClienteOptions

        public ActionResult EditUsuario(int id)
        {
            EditUsuariosViewModel model = new EditUsuariosViewModel();
            using (var db = new Sistema_TicketsEntities())
            {
                var oUserC = db.Usuario_Cliente.Find(id);
                model.ULid = oUserC.ID_Usuarios_Login;

                var oUserL = db.Usuarios_Login.Find(model.ULid);
                model.ULnombre = oUserL.Nombre_Usuarios_Login;
                model.ULestatus = oUserL.Estatus;
                model.ULCcorreo_electronico = oUserL.Correo_electronico;

                model.UCnombre = oUserC.Nombre_UCliente;
                model.UCapellidoP = oUserC.Apellido_PaternoUCliente;
                model.UCapellidoM = oUserC.Apellido_MaternoUCliente;
                model.UcusuarioClave = oUserC.Usuario_Clave;
                model.UCcelular = oUserC.Celular;
                model.UctelOf = oUserC.Telefono_Oficina;
                model.UCext = (int)oUserC.Extension;

                model.UCid = oUserC.ID_Usuario_Cliente;
                model.ULid = oUserL.ID_Usuarios_Login;
                
            }

            return View(model);
        }


     

        [HttpPost]
        public ActionResult EditUsuario(EditUsuariosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Sistema_TicketsEntities())
            {
                var oUserC = db.Usuario_Cliente.Find(model.UCid);
                oUserC.Nombre_UCliente = model.UCnombre;
                oUserC.Apellido_PaternoUCliente = model.UCapellidoP;
                oUserC.Apellido_MaternoUCliente = model.UCapellidoM;
                oUserC.Usuario_Clave = model.UcusuarioClave;
                oUserC.Celular = model.UCcelular;
                oUserC.Telefono_Oficina = model.UCcelular;
                oUserC.Extension = model.UCext;

                var oUserL = db.Usuarios_Login.Find(model.ULid);
                oUserL.Nombre_Usuarios_Login = model.ULnombre;
                oUserL.Estatus = model.ULestatus;
                oUserL.Correo_electronico = model.ULCcorreo_electronico;

                if (model.ULcontraseña != null && model.ULcontraseña.Trim() != "")
                {
                    oUserL.Contraseña = model.ULcontraseña;
                }

                db.Entry(oUserC).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                db.Entry(oUserL).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

                return Content("1");
        }


    }
}