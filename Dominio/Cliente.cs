﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public CondicionTributaria CondicionTributaria { get; set; }

    }
}
