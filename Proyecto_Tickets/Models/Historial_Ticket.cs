//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Tickets.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historial_Ticket
    {
        public int ID_Historial { get; set; }
        public string Estado { get; set; }
        public string Accion_Realizada { get; set; }
        public System.DateTime Fecha_Hora_Modificacion { get; set; }
        public int ID_Estratei { get; set; }
        public int ID_Ticket { get; set; }
    
        public virtual Personal_Estratei Personal_Estratei { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
