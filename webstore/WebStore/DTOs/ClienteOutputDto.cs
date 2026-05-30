namespace WebStore.DTOs
{
    public class ClienteOutputDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateOnly DataNascimento { get; set; }
        public List<PedidoOutputDto> Pedidos { get; set; } = [];
    }
}
