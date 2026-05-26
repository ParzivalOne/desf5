using WebStore.Enums;

namespace WebStore.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public string EnderecoEntrega { get; set; }
        public EStatusPedido Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
