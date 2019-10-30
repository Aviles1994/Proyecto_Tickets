using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tickets.Models;
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