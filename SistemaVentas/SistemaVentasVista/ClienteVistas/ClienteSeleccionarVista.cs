using GestionDePedido.Modelos;
using SistemaVentasBss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasVista.ClienteVistas
{
    public partial class ClienteSeleccionarVista : Form
    {
        public ClienteSeleccionarVista()
        {
            InitializeComponent();
        }

        private void ClienteSeleccionarVista_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                ClienteBss bss = new ClienteBss();
                Cliente c = new Cliente();
                c.Nombre = textBox1.Text;
                c.Apellido = textBox2.Text;
                c.Correo = textBox3.Text;
                c.Telefono = textBox4.Text;
                c.Direccion = textBox5.Text;

                bss.InsertarClienteBss(c);
                MessageBox.Show("se guardo correctamente cliente");
            }
        }
    }
}
