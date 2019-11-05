using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class AddTicketsViewModel
    {
        public DateTime fechaInicio { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime duracionInicio { get; set; }
        public string versionUser { get; set; }
        public string nombreProblema { get; set; }
        public string descrpcionProblema { get; set; }
        public string imagen { get; set; }
        public DateTime fechafin { get; set; }
        public DateTime horafin { get; set; }
        public int ID_Pantalla { get; set; }
        public int ID_usuarioCliente{ get; set; }
        public int ID_MedioContacto { get; set; }
        public int ID_Servico { get; set; }
        public int ID_Estado { get; set; }
        public int ID_Prioridad { get; set; }
    }
}