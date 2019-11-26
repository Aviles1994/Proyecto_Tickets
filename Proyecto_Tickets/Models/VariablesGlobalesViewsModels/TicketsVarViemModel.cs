using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.VariablesGlobalesViewsModels
{
    public class TicketsVarViemModel
    {
        public static int idTickets { get; set; }

        public int ID_cliente { get; set; }
        public int ID_usuarioCliente { get; set; }
    }

    public class ElegidoTickets
    {
        public int ID_Ticket { get; set; }

        public int ID_cliente { get; set; }
        public int ID_usuarioCliente { get; set; }
    }

}