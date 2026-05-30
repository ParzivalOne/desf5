using WebStore.Enums;

namespace WebStore.DTOs
{
    public class PedidoCreateInputDto
    {
        public Guid ClienteId { get; set; }
        public List<ItemPedidoCreateInputDto> ItensPedido { get; set; }
        public string EnderecoEntrega { get; set; }
        public EStatusPedido Status { get; set; }
    }
}
