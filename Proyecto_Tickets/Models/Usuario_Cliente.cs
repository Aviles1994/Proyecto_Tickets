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
    
    public partial class Usuario_Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario_Cliente()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int ID_Usuario_Cliente { get; set; }
        public string Nombre_UCliente { get; set; }
        public string Apellido_PaternoUCliente { get; set; }
        public string Apellido_MaternoUCliente { get; set; }
        public bool Usuario_Clave { get; set; }
        public bool Estatus { get; set; }
        public string Celular { get; set; }
        public string Telefono_Oficina { get; set; }
        public Nullable<int> Extension { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Usuarios_Login { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
