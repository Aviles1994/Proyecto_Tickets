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
    
    public partial class Usuarios_Login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios_Login()
        {
            this.Personal_Estratei = new HashSet<Personal_Estratei>();
            this.Usuario_Cliente = new HashSet<Usuario_Cliente>();
        }
    
        public int ID_Usuarios_Login { get; set; }
        public string Nombre_Usuarios_Login { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus { get; set; }
        public Nullable<System.DateTime> Ultimo_Login { get; set; }
        public string Correo_electronico { get; set; }
        public int ID_Tipo_Usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Estratei> Personal_Estratei { get; set; }
        public virtual Tipo_Usuarios Tipo_Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_Cliente> Usuario_Cliente { get; set; }
    }
}