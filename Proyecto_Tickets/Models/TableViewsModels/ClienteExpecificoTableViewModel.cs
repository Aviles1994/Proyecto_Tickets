﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tickets.Models.TableViewsModels
{
    public class ClienteExpecificoTableViewModel
    {
        public int idCliente { get; set; }
        public string NameCliente { get; set; }
        public string Calle { get; set; }
        public string numero { get; set; }
        public string colonia { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public int etidad_feerativa { get; set; }
    }

    public class getCliente
    {

        public int id { get; set; }
        public string namecliente { get; set; }
    }
}