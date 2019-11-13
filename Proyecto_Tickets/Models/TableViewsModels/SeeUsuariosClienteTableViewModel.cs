using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class SeeUsuariosClienteTableViewModel
    {
        public int iduserC { get; set; }
        public string  NombreC{ get; set; }
        public string  ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public bool UseClave { get; set; }
        public string Celular { get; set; }
        public string TelOfi { get; set; }
        public int Extencion { get; set; }
        public int iduser{ get; set; }
        public int idCliente { get; set; }

       

    }
}