using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class AddSolucionViewModel
    {
        public string  Descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int idticket { get; set; }
        public int idEstratei { get; set; }
    }
}