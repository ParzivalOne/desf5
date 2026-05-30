using WebStore.DTOs;

namespace WebStore.Models
{
    public class ItemPedido
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedidoOutputDto ToOutputDto()
        {
            return new ItemPedidoOutputDto
            {
                Id = Id,
                ProdutoId = ProdutoId,
                Quantidade = Quantidade
            };
        }
    }
}
