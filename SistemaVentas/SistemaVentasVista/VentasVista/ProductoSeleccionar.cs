using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVentasBss;

namespace SistemaVentasVista.VentasVista
{
    public partial class ProductoSeleccionar : Form
    {
        public ProductoSeleccionar()
        {
            InitializeComponent();
        }

        ProductoBss bss = new ProductoBss();
        private void button1_Click(object sender, EventArgs e)
        {
            DetallesVentasVista.IdProductoSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

        }
       
        private void ProductoSeleccionar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarProductoBss();
        }
    }
    }

