using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class SeeHistorial
    {
        public int ID_Historial { get; set; }
        public string Accion_Realizada { get; set; }
        public DateTime Fecha_Hora_Modificacion { get; set; }

        public int ID_Estratei { get; set; }
        public string Nombre_Personal { get; set; }

        public int ID_Estado { get; set; }
        public string Nombre_Estado { get; set; }

        public int ID_Ticket { get; set; }
    }
}
