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
        public int idTicket { get; set; }
        public string Nombre_Problema { get; set; }
        public string descripción_problema { get; set; }
        public string descrpcion_solucion { get; set; }
        public int idpantalla { get; set; }
        public string nombre_pantalla { get; set; }

    }
}