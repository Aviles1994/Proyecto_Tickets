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

        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public bool ULestatus { get; set; }
        public DateTime ULUltimoLogin { get; set; }
        public string ULCcorreo_electronico { get; set; }
        public int ULTipoUsuario { get; set; }



    }
}