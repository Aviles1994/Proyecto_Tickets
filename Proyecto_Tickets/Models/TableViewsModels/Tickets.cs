using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class SeeTicketsUsuarios
    {
        public int idTicket { get; set; }
        public DateTime fecha_inicio { get; set; }
        public string version_usuario { get; set; }
        public string nombre_problema { get; set; }
        public string descripción_problema { get; set; }
        public DateTime fecha_fin { get; set; }

        public int idpantalla { get; set; }
        public string Nombre_Pantalla { get; set; }

        public int idusuario { get; set; }
        public string Nombre_Usuario { get; set; }

        public int idmedio_contacto { get; set; }
        public string Nombre_MedioContacto { get; set; }

        public int idservicio { get; set; }
        public string Nombre_Servicio { get; set; }

        public int idestado { get; set; }
        public string Nombre_Estado { get; set; }

        public int idprioridad { get; set; }
        public string Nombre_Prioridad { get; set; }

    }

    public class SeeTicketsPendientes
    {
        public int idTicket { get; set; }
        public DateTime fecha_inicio { get; set; }
        public string version_usuario { get; set; }
        public string nombre_problema { get; set; }
        public string descripción_problema { get; set; }
        public DateTime fecha_fin { get; set; }

        public int idpantalla { get; set; }
        public string Nombre_Pantalla { get; set; }

        public int idusuario { get; set; }
        public string Nombre_Usuario { get; set; }

        public int idmedio_contacto { get; set; }
        public string Nombre_MedioContacto { get; set; }

        public int idservicio { get; set; }
        public string Nombre_Servicio { get; set; }

        public int idestado { get; set; }
        public string Nombre_Estado { get; set; }

        public int idprioridad { get; set; }
        public string Nombre_Prioridad { get; set; }

    }

    public class SeeTicketsNumero
    {
        public int idTicket { get; set; }
        public DateTime fecha_inicio { get; set; }
        public string version_usuario { get; set; }
        public string nombre_problema { get; set; }
        public string descripción_problema { get; set; }
        public DateTime fecha_fin { get; set; }
   
        public int idpantalla { get; set; }
        public string Nombre_Pantalla { get; set; }

        public int idusuario { get; set; }
        public string Nombre_Usuario { get; set; }

        public int idmedio_contacto { get; set; }
        public string Nombre_MedioContacto { get; set; }

        public int idservicio { get; set; }
        public string Nombre_Servicio { get; set; }

        public int idestado { get; set; }
        public string Nombre_Estado { get; set; }

        public int idprioridad { get; set; }
        public string Nombre_Prioridad { get; set; }

    }

}