using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
