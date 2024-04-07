﻿using SistemaVentasBss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasVista.VentasVista
{
    public partial class VentaSeleccionar : Form
    {
        public VentaSeleccionar()
        {
            InitializeComponent();
        }
        VentaBss bss = new VentaBss();

        private void button1_Click(object sender, EventArgs e)
        {
            DetallesVentasVista.IdVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VentaSeleccionar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarVentaBss();
        }
    }
}