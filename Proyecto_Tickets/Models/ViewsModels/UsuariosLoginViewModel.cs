using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class UsuariosLoginViewModel
    {
        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public string UCestatus { get; set; }
        public DateTime UCUltimoLogin { get; set; }
        public string UCcorreo_electronico { get; set; }
        public int ID_Tipo_Usuario { get; set; }
    }
}