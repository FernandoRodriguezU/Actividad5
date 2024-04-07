using SistemaGestion.DAL;
using SistemaVentasModelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasBss
{
    public class PedidoBss
    {
        PedidoDal dal = new PedidoDal();
        public DataTable ListarPedidoBss()
        {
            return dal.ListarPedidoDal();
        }

        public void InsertarPedidoBss(Pedido pedido)
        {
            dal.InsertarPedidoDal(pedido);
        }

        public Pedido ObtenerPedidoIdBss(int id)
        {
            return dal.ObtenerPedidoId(id);
        }

        public void EditarPedidoBss(Pedido pedido)
        {
            dal.EditarPedidoDal(pedido);
        }

        public void EliminarPedidoBss(int id)
        {
            dal.EliminarPedidoDal(id);
        }
        public DataTable CalcularPedidosClienteBss(int ID)
        {
            return dal.CalcularTotalClienteDal(ID);
        }

    }
}
