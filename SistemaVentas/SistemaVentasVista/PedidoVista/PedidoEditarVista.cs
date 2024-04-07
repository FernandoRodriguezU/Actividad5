using GestionDePedido.Modelos;
using SistemaVentasBss;
using SistemaVentasModelos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaVentasVista.PedidoVista
{
    public partial class PedidoEditarVista : Form
    {
        int idx = 0;
        Pedido p = new Pedido();
        PedidoBss bss = new PedidoBss();
        public PedidoEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void PedidoEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerPedidoIdBss(idx);
            textBox1.Text = p.IdCliente.ToString();
            dateTimePicker1.Value = p.Fecha;
            textBox3.Text = p.Total.ToString();
            textBox4.Text = p.Estado;
        }
        public static int IdClienteSeleccionado = 0;
        ClienteBss bsscliente = new ClienteBss();

        private void button3_Click(object sender, EventArgs e)
        {
            ClienteListarVista fr = new ClienteListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
          
                Cliente cliente = bsscliente.ObtenerIdBss(IdClienteSeleccionado);
                textBox1.Text = cliente.Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdCliente = IdClienteSeleccionado;
            p.Fecha = dateTimePicker1.Value;
            p.Total = Convert.ToDecimal(textBox3.Text);
            p.Estado = textBox4.Text;

            bss.EditarPedidoBss(p);
            MessageBox.Show("Datos Actualizados");
        }
    }
}
