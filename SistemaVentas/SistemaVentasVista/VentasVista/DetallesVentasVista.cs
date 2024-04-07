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
    public partial class DetallesVentasVista : Form
    {
        public DetallesVentasVista()
        {
            InitializeComponent();
            this.textBox3.TextChanged += new EventHandler(textBox3_TextChanged);
            this.textBox4.TextChanged += new EventHandler(textBox4_TextChanged);
        }
        DetalleVentaBss bss = new DetalleVentaBss();
        VentaBss bssvent = new VentaBss();
        ProductoBss bssprod = new ProductoBss();
        public static int IdVentaSeleccionada = 0;
        public static int IdProductoSeleccionada = 0;

        private void DetallesVentasVista_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarDetalleVentaBss();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MultiplicarValores();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MultiplicarValores();
        }
        private void MultiplicarValores()
        {
            if (double.TryParse(textBox3.Text, out double valor1) &&
                double.TryParse(textBox4.Text, out double valor2))
            {
                textBox5.Text = (valor1 * valor2).ToString();
            }
            else
            {
                textBox5.Text = "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdDetalleVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Esta seguro que lo desea eliminar?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarDetalleVentaBss(IdDetalleVentaSeleccionada);
                dataGridView1.DataSource = bss.ListarDetalleVentaBss();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleVenta d = new DetalleVenta();
            d.IdVenta = IdVentaSeleccionada;
            d.IdProducto = IdProductoSeleccionada;
            d.Cantidad = Convert.ToInt32(textBox3.Text);
            d.PrecioUnitario = Convert.ToDecimal(textBox4.Text);
            d.TotalDetalle = Convert.ToDecimal(textBox5.Text);

            bss.InsertarDetalleVentaBss(d);
            MessageBox.Show("Se guardo correctamente El detalle de la venta");
            dataGridView1.DataSource = bss.ListarDetalleVentaBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IdDetalleVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DetalleVenta editarDetalleVenta = bss.ObtenerDetalleVentaIdBss(IdDetalleVentaSeleccionada);
            editarDetalleVenta.IdVenta = IdVentaSeleccionada;
            editarDetalleVenta.IdProducto = IdProductoSeleccionada;
            editarDetalleVenta.Cantidad = Convert.ToInt32(textBox3.Text);
            editarDetalleVenta.PrecioUnitario = Convert.ToDecimal(textBox4.Text);
            editarDetalleVenta.TotalDetalle = Convert.ToDecimal(textBox5.Text);
            bss.EditarDetalleVentaBss(editarDetalleVenta);
            MessageBox.Show("Datos Actualizados");


            dataGridView1.DataSource = bss.ListarDetalleVentaBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IdDetalleVentaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            VentaDatos fr = new VentaDatos(IdDetalleVentaSeleccionada);
            fr.ShowDialog();
            bss.DetalleVentaDatosBSS(IdDetalleVentaSeleccionada);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            VentaSeleccionar fr = new VentaSeleccionar();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Venta v = bssvent.ObtenerVentaIdBss(IdVentaSeleccionada);
                textBox1.Text = v.TotalVenta.ToString();
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            ProductoSeleccionar fr = new ProductoSeleccionar();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Producto p = bssprod.ObtenerProductoIdBss(IdProductoSeleccionada);
                textBox2.Text = p.NombreProducto;
            }
        }
    }
}
