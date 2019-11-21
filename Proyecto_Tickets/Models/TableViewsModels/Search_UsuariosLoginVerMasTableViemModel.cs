using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class VerMas
    {
        public int idl { get; set; }
        public string nameL { get; set; }
        public string  contraseña { get; set; }
        public bool estatus { get; set; }
        public DateTime ultimoLogin { get; set; }
        public string correo { get; set; }

    }
}