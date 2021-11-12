﻿using Presentador.Presentadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador
{
    public partial class ListaProducto : Form
    {
        private PresentadorListaProducto _presentadorLista;       
        public int codigo1;
        public ListaProducto()
        {
            InitializeComponent();
            _presentadorLista = new PresentadorListaProducto(this, dvgProductos);           
        }

        private void ListaProducto_Load(object sender, EventArgs e)
        {
            _presentadorLista.Load();
        }

        private void dvgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
           // {                
                codigo1 = Convert.ToInt32(dvgProductos.Rows[e.RowIndex].Cells[0].Value.ToString());              
                if (e.ColumnIndex == 7)
                {
                    _presentadorLista.VerMas(codigo1);
                }
          //  }
            /*catch (FormatException)
            {
                
            }*/
            
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            _presentadorLista.Agregar();
        }
    }
}
