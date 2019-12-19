using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class AddTicketsViewModel
    {
        public int idt { get; set; }
        public DateTime fecha_hora_Inicio { get; set; }
        public DateTime duracionInicio { get; set; }
        public string versionUser { get; set; }
        public string nombreProblema { get; set; }
        public string descrpcionProblema { get; set; }
        public string imagen { get; set; }
        public DateTime fecha_hora_fin { get; set; }
        
        public int ID_Sistema{ get; set; }
        public int ID_Modulo { get; set; }
        public int ID_Pantalla { get; set; }

        public int ID_cliente { get; set; }
        public int ID_usuarioCliente{ get; set; }

        public int ID_MedioContacto { get; set; }
        public int ID_Servico { get; set; }
        public int ID_Estado { get; set; }
        public int ID_Prioridad { get; set; }
    }


    public class EditEstado
    {
        public int idTicket { get; set; }
        public string nombreProblema { get; set; }
        public string descrpcionProblema { get; set; }
        public int idEstado { get; set; }
        public DateTime fecha_hora_fin { get; set; }
    }

    public class VerMasTicket
    {
        public string Nombre_Pantalla { get; set; }
        public string Nombre_Usuario_Cliente { get; set; }
        public string Nombre_Medio_Contacto { get; set; }
        public string Nombre_Servicio { get; set; }
        public string Nombre_Estado { get; set; }
        public string Nombre_Prioridad { get; set; }
    }
}