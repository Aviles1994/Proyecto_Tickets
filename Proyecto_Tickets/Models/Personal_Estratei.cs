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
    
    public partial class Personal_Estratei
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_Estratei()
        {
            this.Historial_Ticket = new HashSet<Historial_Ticket>();
            this.Solucion = new HashSet<Solucion>();
        }
    
        public int ID_Estratei { get; set; }
        public string Nombre_PEstratei { get; set; }
        public string Apellido_PaternoPEstratei { get; set; }
        public string Apellido_MaternoPEstratei { get; set; }
        public string Celular { get; set; }
        public int ID_Departamento { get; set; }
        public int ID_Usuarios_Login { get; set; }
    
        public virtual Departamento Departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial_Ticket> Historial_Ticket { get; set; }
        public virtual Usuarios_Login Usuarios_Login { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solucion> Solucion { get; set; }
    }
}
