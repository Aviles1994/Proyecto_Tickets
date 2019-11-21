using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
using Proyecto_Tickets.Models.TableViewsModels;
using Proyecto_Tickets.Models.VariablesGlobalesViewsModels;

namespace Proyecto_Tickets.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string user, string contraseña)
        {
            try
            {
                using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
                {
                    var lst = from d in db.Usuarios_Login
                              where d.Nombre_Usuarios_Login == user && d.Contraseña == contraseña && d.Estatus == true
                              select d;
                    if (lst.Count() > 0)
                    {
                        Usuarios_Login oUser = lst.First();
                        Session["user"] = oUser;
                        UserSession.iduser = oUser.ID_Usuarios_Login;
                        UserSession.nombre_user = oUser.Nombre_Usuarios_Login;
                        ViewData["nombre_user"] = UserSession.nombre_user; 
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }

                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }

        }
    

}
}