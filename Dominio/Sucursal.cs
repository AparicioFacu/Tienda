﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sucursal
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Sucursal()
        {

        }
        public Sucursal(int id)
        {
            this.Id = id;
        }
    }
}
