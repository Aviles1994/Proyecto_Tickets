using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{

    public class Buscar
    {

        
        [Required]
        [DataType(DataType.Text)]
        public string Nombre_Problema { get; set; }
        
    }
    public class SeeProblema
    {
        public int idTicket { get; set; }
        public string Nombre_Problema { get; set; }
        public string descripción_problema { get; set; }
        public string descrpcion_solucion { get; set; }
        public int idpantalla { get; set; }
        public string nombre_pantalla { get; set; }

    }

    public class Especifico
    {
        public int idSolucion { get; set; }
        public int idTicket { get; set; }
        public string Nombre_Problema { get; set; }
        public string descripción_problema { get; set; }
        public string descrpcion_solucion { get; set; }
        public int idpantalla { get; set; }
        public string nombre_pantalla { get; set; }

    }

    public class VerMasProblema
    {
        public string Descripcion_Solucion { get; set; }
        public DateTime Fecha_Solucion { get; set; }

        public DateTime fecha_hora_Inicio { get; set; }
        public string versionUser { get; set; }
        public string nombreProblema { get; set; }
        public string descrpcionProblema { get; set; }
        public DateTime fecha_hora_Fin { get; set; }

        public string Nombre_Pantalla { get; set; }
        public string Nombre_Usuario_Cliente { get; set; }
        public string Nombre_Medio_Contacto { get; set; }
        public string Nombre_Servicio { get; set; }
        public string Nombre_Estado { get; set; }
        public string Nombre_Prioridad { get; set; }


        public string Nombre_Personal { get; set; }
        public string ApellidoP_Personal { get; set; }
        public string ApellidoM_Personal { get; set; }
        public string Celular { get; set; }
        public string Puesto { get; set; }
    }
}