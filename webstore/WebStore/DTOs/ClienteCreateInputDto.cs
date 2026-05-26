namespace WebStore.DTOs
{
    public class ClienteCreateInputDto
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
