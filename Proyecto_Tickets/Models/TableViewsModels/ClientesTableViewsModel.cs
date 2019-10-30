using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class ClientesTableViewsModel
    {
        public int ID_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public int ID_Entidad_Federativa { get; set; }

    }
}