﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Sistema_TicketsEntities : DbContext
    {
        public Sistema_TicketsEntities()
            : base("name=Sistema_TicketsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Entidad_Federativa> Entidad_Federativa { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Historial_Ticket> Historial_Ticket { get; set; }
        public virtual DbSet<Medio_de_Contacto> Medio_de_Contacto { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Pantallas> Pantallas { get; set; }
        public virtual DbSet<Personal_Estratei> Personal_Estratei { get; set; }
        public virtual DbSet<Prioridad> Prioridad { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }
        public virtual DbSet<Sistema_Cliente> Sistema_Cliente { get; set; }
        public virtual DbSet<Solucion> Solucion { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Tipo_Usuarios> Tipo_Usuarios { get; set; }
        public virtual DbSet<Usuarios_Login> Usuarios_Login { get; set; }
        public virtual DbSet<Usuario_Cliente> Usuario_Cliente { get; set; }
    }
}
