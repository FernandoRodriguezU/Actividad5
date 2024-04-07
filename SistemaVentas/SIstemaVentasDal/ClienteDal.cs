using GestionDePedido.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentasModelos;
using GestionDePedido.Modelos;

namespace SIstemaVentasDal
{
    public class ClienteDal
    {
        public DataTable ListarClienteDal()
        {
            string consulta = "select * from cliente";
            DataTable Lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return Lista;
        }
        
        public void InsertarClienteDal(Cliente cliente)
        {
            string consulta = "insert into cliente values('" + cliente.Nombre + "'," +
                                                        "'" + cliente.Apellido + "'," +
                                                        "'" + cliente.Correo + "'," +
                                                        "'" + cliente.Telefono + "'," +
                                                        "'" + cliente.Direccion + "')";
            conexion.Ejecutar(consulta);
        }
        public Cliente ObtenerClienteId(int id)
        {
            string consulta = "select * from cliente where idcliente = " + id;
            DataTable tabla = conexion.EjecutarDataTabla(consulta, "asdas");
            Cliente cliente = new Cliente();
            if (tabla.Rows.Count > 0)
            {
                cliente.IdCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"]);
                cliente.Nombre = tabla.Rows[0]["nombre"].ToString();
                cliente.Apellido = tabla.Rows[0]["apellido"].ToString();
                cliente.Correo = tabla.Rows[0]["correoelectronico"].ToString();
                cliente.Telefono = tabla.Rows[0]["telefono"].ToString();
                cliente.Direccion = tabla.Rows[0]["direccion"].ToString();

            }
            return cliente;

        }
        public void EditarClienteDal(Cliente c)
        {
            string consulta = "update cliente set nombre='" + c.Nombre + "'," +
                                                  "apellido='" + c.Apellido + "'," +
                                                  "correo='" + c.Correo + "'," +
                                                  "telefono='" + c.Telefono + "'," +
                                                  "direccion='" + c.Direccion + "'" +
                                              "where idcliente=" + c.IdCliente;
            conexion.Ejecutar(consulta);
        }
        public void EliminarClienteDal(int id)
        {
            string consulta = "delete from cliente where idcliente=" + id;
            conexion.Ejecutar(consulta);
        }
    }
}
