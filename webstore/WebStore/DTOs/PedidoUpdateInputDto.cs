using WebStore.Enums;

namespace WebStore.DTOs
{
    public class PedidoUpdateInputDto
    {
        public string? EnderecoEntrega { get; set; }
        public EStatusPedido? Status { get; set; }
    }
}
