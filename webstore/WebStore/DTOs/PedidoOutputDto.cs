using WebStore.Enums;

namespace WebStore.DTOs
{
    public class PedidoOutputDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public List<ItemPedidoOutputDto> ItensPedido { get; set; }
        public string EnderecoEntrega { get; set; }
        public EStatusPedido Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
