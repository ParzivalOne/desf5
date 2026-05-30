namespace WebStore.DTOs
{
    public class ItemPedidoOutputDto
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
