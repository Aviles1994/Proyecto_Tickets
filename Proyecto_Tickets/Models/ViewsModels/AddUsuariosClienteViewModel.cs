using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.ViewsModels
{
    public class AddUsuariosClienteViewModel
    {
        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public bool ULestatus { get; set; }
        public DateTime ULUltimoLogin { get; set; }
        public string ULCcorreo_electronico { get; set; }
        public int ID_Tipo_Usuario { get; set; }

        public string UCnombre { get; set; }
        public string UCapellidoP { get; set; }
        public string UCapellidoM { get; set; }
        public bool UcusuarioClave { get; set; }
        public string UCcelular { get; set; }
        public string UctelOf { get; set; }
        public int UCext { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Usurios_Login { get; set; }
    }


    public class AddUsuariosOptionsClienteViewModel
    {
        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public bool ULestatus { get; set; }
        public DateTime ULUltimoLogin { get; set; }
        public string ULCcorreo_electronico { get; set; }
        public int ID_Tipo_Usuario { get; set; }

        public string UCnombre { get; set; }
        public string UCapellidoP { get; set; }
        public string UCapellidoM { get; set; }
        public bool UcusuarioClave { get; set; }
        public string UCcelular { get; set; }
        public string UctelOf { get; set; }
        public int UCext { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Usurios_Login { get; set; }
    }

    public class EditUsuariosViewModel
    {
        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public bool ULestatus { get; set; }
        public DateTime ULUltimoLogin { get; set; }
        public string ULCcorreo_electronico { get; set; }


        public int UCid { get; set; }
        public string UCnombre { get; set; }
        public string UCapellidoP { get; set; }
        public string UCapellidoM { get; set; }
        public bool UcusuarioClave { get; set; }
        public string UCcelular { get; set; }
        public string UctelOf { get; set; }
        public int UCext { get; set; }

    }

    public class DeleteUsuarioCliente
    {
        public int ULid { get; set; }
        public string ULnombre { get; set; }
        public string ULcontraseña { get; set; }
        public bool ULestatus { get; set; }
        public DateTime ULUltimoLogin { get; set; }
        public string ULCcorreo_electronico { get; set; }


        public int UCid { get; set; }
        public string UCnombre { get; set; }
        public string UCapellidoP { get; set; }
        public string UCapellidoM { get; set; }
        public bool UcusuarioClave { get; set; }
        public string UCcelular { get; set; }
        public string UctelOf { get; set; }
        public int UCext { get; set; }

    }

}