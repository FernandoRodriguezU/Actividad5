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
using SistemaVentasModelos;

namespace SistemaVentasVista.VentasVista
{
    public partial class VentasVistas : Form
    {
        public VentasVistas()
        {
            InitializeComponent();
        }
        VentaBss bss = new VentaBss();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VentasVistas_Load(object sender, EventArgs e)
        {
                dataGridView1.DataSource = bss.ListarVentaBss();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Venta u = new Venta();
            u.TotalVenta = Convert.ToDecimal(textBox1.Text);
            u.FechaVenta = dateTimePicker1.Value;

            bss.InsertarVentaBss(u);
            MessageBox.Show("Se guardo correctamente ");
            dataGridView1.DataSource = bss.ListarVentaBss();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int IdVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Venta editarVenta = bss.ObtenerVentaIdBss(IdVentaSeleccionada);
            editarVenta.TotalVenta = Convert.ToDecimal(textBox1.Text);
            editarVenta.FechaVenta = dateTimePicker1.Value;
            bss.EditarVentaBss(editarVenta);
            MessageBox.Show("Datos Actualizados");

            dataGridView1.DataSource = bss.ListarVentaBss();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int IdVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar a esta venta?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarVentaBss(IdVentaSeleccionada);
                dataGridView1.DataSource = bss.ListarVentaBss();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venta u = new Venta();
            u.TotalVenta = Convert.ToDecimal(textBox1.Text);
            u.FechaVenta = dateTimePicker1.Value;

            bss.InsertarVentaBss(u);
            MessageBox.Show("Se guardo correctamente ");
            dataGridView1.DataSource = bss.ListarVentaBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IdVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Venta editarVenta = bss.ObtenerVentaIdBss(IdVentaSeleccionada);
            editarVenta.TotalVenta = Convert.ToDecimal(textBox1.Text);
            editarVenta.FechaVenta = dateTimePicker1.Value;
            bss.EditarVentaBss(editarVenta);
            MessageBox.Show("Datos Actualizados");

            dataGridView1.DataSource = bss.ListarVentaBss();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar a esta venta?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarVentaBss(IdVentaSeleccionada);
                dataGridView1.DataSource = bss.ListarVentaBss();
            }
        }
    }
}
