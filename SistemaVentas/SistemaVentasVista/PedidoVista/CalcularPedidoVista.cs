using GestionDePedido.Modelos;
using SistemaVentasBss;
using SistemaVentasVista.ClienteVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasVista.PedidoVista
{
    public partial class CalcularPedidoVista : Form
    {
        public CalcularPedidoVista()
        {
            InitializeComponent();
        }
        public static int IdClienteSeleccionado = 0;
        ClienteBss bsscliente = new ClienteBss();
        private void CalcularPedidoVista_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteListarVista fr = new ClienteListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Cliente cliente = bsscliente.ObtenerIdBss(IdClienteSeleccionado);
                textBox1.Text = cliente.Nombre;


            }
        }
        PedidoBss bss = new PedidoBss();
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.CalcularPedidosClienteBss(IdClienteSeleccionado);
        }
    }
}
