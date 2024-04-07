using GestionDePedido.DAL;
using SistemaVentasModelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SistemaGestion.DAL
{
    public class PedidoDal
    {
        public DataTable ListarPedidoDal()
        {
            string consulta = "select * from pedido";
            DataTable lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }

        public void InsertarPedidoDal(Pedido pedido)
        {
            string consulta = "insert into pedido values(" + pedido.IdCliente + "," +
                                                         "'" + pedido.Fecha + "'," +
                                                         "" + pedido.Total + "," +
                                                         "'" + pedido.Estado + "')";
            conexion.Ejecutar(consulta);
        }

        public Pedido ObtenerPedidoId(int id)
        {
            string consulta = "select * from pedido where idpedido = " + id;
            DataTable tabla = conexion.EjecutarDataTabla(consulta, "asdas");
            Pedido pedido = new Pedido();
            if (tabla.Rows.Count > 0)
            {
                pedido.IdPedido = Convert.ToInt32(tabla.Rows[0]["idpedido"]);
                pedido.IdCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"]);
                pedido.Fecha = Convert.ToDateTime(tabla.Rows[0]["fecha"]);
                pedido.Total = Convert.ToDecimal(tabla.Rows[0]["total"]);
                pedido.Estado = tabla.Rows[0]["estado"].ToString();
            }
            return pedido;
        }

        public void EditarPedidoDal(Pedido pedido)
        {
            string consulta = "update pedido set idcliente =" + pedido.IdCliente + "," +
                                                    "fecha ='" + pedido.Fecha + "'," +
                                                    "total =" + pedido.Total + "," +
                                                    "estado='" + pedido.Estado + "' " +
                                    "where idpedido=" + pedido.IdPedido;

            conexion.Ejecutar(consulta);
        }

        public void EliminarPedidoDal(int id)
        {
            string consulta = "delete from pedido where idpedido =" + id;
            conexion.Ejecutar(consulta);
        }

        public DataTable CalcularTotalClienteDal(int id)
        {
            string consulta = "SELECT Cliente.Nombre, Cliente.Apellido, Count(Pedido.IDPedido) AS PEDIDOS, sum(Pedido.Total) AS CANTIDAD " +
                                "FROM Cliente INNER JOIN " +
                                                         "Pedido ON Cliente.IDCliente = Pedido.IDCliente " +
                               "WHERE cliente.IDCLIENTE = " + id +
                               "GROUP BY Cliente.Nombre, Cliente.Apellido ";
            DataTable lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }

    }
}