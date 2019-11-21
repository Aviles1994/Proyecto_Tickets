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
        public float versionUser { get; set; }
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
}