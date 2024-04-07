using SistemaVentasBss;
using SistemaVentasModelos;
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
    public partial class VentaDatos : Form
    {
        public VentaDatos(int id)
        {
            idx = id;
            InitializeComponent();
        }
        int idx = 0;
        DetalleVenta c = new DetalleVenta();
        DetalleVentaBss bss = new DetalleVentaBss();
        private void VentaDatos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.DetalleVentaDatosBSS(idx);
        }
    }
}
