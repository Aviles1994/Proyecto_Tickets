using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tickets.Controllers
{
    public class UsuariosClienteOptionsController : Controller
    {
        // GET: UsuariosClienteOptions

        [HttpGet]
        public ActionResult DeleteUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new Sistema_TicketsEntities();
            DeleteUsuarioCliente odelete = new DeleteUsuarioCliente();
            var ouserC = db.Usuario_Cliente.Find(id);
            odelete.UCid = ouserC.ID_Cliente;
            odelete.UCnombre = ouserC.Nombre_UCliente;
            odelete.UCapellidoP = ouserC.Apellido_PaternoUCliente;
            odelete.UCapellidoM = ouserC.Apellido_MaternoUCliente;
            odelete.UCcelular= ouserC.Celular;
            odelete.UctelOf = ouserC.Telefono_Oficina;
            odelete.UCext = (int)ouserC.Extension;


            var ouserL = db.Usuarios_Login.Find(ouserC.ID_Usuarios_Login);
            odelete.ULCcorreo_electronico = ouserL.Correo_electronico;
            odelete.ULnombre = ouserL.Nombre_Usuarios_Login;
            odelete.ULUltimoLogin = ouserL.Ultimo_Login;
            odelete.ULcontraseña = ouserL.Contraseña;
            odelete.ULestatus = ouserL.Estatus;

            if (ouserL == null)
            {
                return HttpNotFound();
            }

            return View(odelete);
        }

        [HttpPost]
        public ActionResult DeleteUsuario(DeleteUsuarioCliente model)
        {
            var db = new Sistema_TicketsEntities();
            var oUserC = db.Usuario_Cliente.Find(model.UCid);
            var oUserL = db.Usuarios_Login.Find(oUserC.ID_Usuarios_Login);
            db.Usuario_Cliente.Remove(oUserC);
            db.SaveChanges();
            db.Usuarios_Login.Remove(oUserL);
            db.SaveChanges();

            return RedirectToAction("SeeClientes");
        }
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

        [HttpGet]
        public ActionResult VerMas(int id)
        {
             
            List<SeeUsuariosClienteTableViewModel> lst = null;
            using (var abc = new Sistema_TicketsEntities())
            {
                var oUserL = abc.Usuarios_Login.Find(id);
                if (oUserL != null)
                {

                    lst = (from d in abc.Usuarios_Login
                           where d.ID_Usuarios_Login == oUserL.ID_Usuarios_Login

                           select new SeeUsuariosClienteTableViewModel
                           {
                               ULid = d.ID_Usuarios_Login,
                               ULnombre = d.Nombre_Usuarios_Login,
                               ULcontraseña = d.Contraseña,
                               ULestatus = d.Estatus,
                               ULUltimoLogin = d.Ultimo_Login,
                               ULCcorreo_electronico = d.Correo_electronico,
                               ULTipoUsuario = d.ID_Tipo_Usuario
                           }).ToList();
                    return View(lst);
                }
                

            }
            return View();

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