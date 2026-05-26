namespace WebStore.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public List<Pedido>? Pedidos { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
