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
    public partial class ClienteEditarVista : Form
    {
        int idx = 0;
        Cliente c = new Cliente();
        ClienteBss bss = new ClienteBss();
        public ClienteEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Nombre = textBox1.Text;
            c.Apellido = textBox2.Text;
            c.Correo = textBox3.Text;
            c.Telefono = textBox4.Text;
            c.Direccion = textBox5.Text;

            bss.EditarClienteBss(c);
            MessageBox.Show("Datos actualizados");
        }

        private void ClienteEditarVista_Load(object sender, EventArgs e)
        {
            c = bss.ObtenerIdBss(idx);
            textBox1.Text = c.Nombre;
            textBox2.Text = c.Apellido;
            textBox3.Text = c.Correo;
            textBox4.Text = c.Telefono;
            textBox5.Text = c.Direccion;
        }
    }
}
