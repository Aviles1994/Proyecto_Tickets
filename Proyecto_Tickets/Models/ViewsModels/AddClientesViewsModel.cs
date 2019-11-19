using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class AddClientesViewsModel
    {

        
        public string Nombre_Cliente { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public int  ID_EF { get; set; }

        public int ID_Sistema { get; set; }
        public DateTime fecha_contrato { get; set; }
        public float version_sis { get; set; }
        public DateTime  vigencia { get; set; }

    }


    public class EditClientesViewModel
    {

        public int id_c { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }

        public DateTime fecha_contrato { get; set; }
        public float version_sis { get; set; }
        public DateTime vigencia { get; set; }

    }
}