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

        public ActionResult Enter(string Nombre_Usuario_Login, string contraseña)
        {
            try
            {
                using (Sistema_TicketsEntities db = new Sistema_TicketsEntities())
                {
                    var lst = from d in db.Usuarios_Login
                              where d.Nombre_Usuarios_Login == Nombre_Usuario_Login && d.Contraseña == contraseña && d.Estatus == true
                              select d;
                    if (lst.Count() > 0)
                    {
                        var obtener = lst.First();
                        Session["Nombre_Usuario_Login"] = obtener;
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