using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;

namespace WebStore.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Pedido> Pedidos { get; set; } = [];
        public DateTime DataCriacao { get; set; }
        public DateOnly DataNascimento { get; set; }

        public static Cliente MapFrom<T>(T input) where T : class
        {
            if (input is null) throw new ArgumentNullException(nameof(input));

            return input switch
            {
                ClienteCreateInputDto c => new Cliente
                {
                    Nome = c.Nome,
                    Documento = c.Documento, 
                    Telefone = c.Telefone,
                    Email = c.Email,
                    DataNascimento = c.DataNascimento,
                    DataCriacao = DateTime.UtcNow
                },
                ClienteUpdateInputDto u => new Cliente
                {
                    Telefone = u.Telefone,
                    Email = u.Email
                },
                Cliente existing => existing,
                _ => throw new ArgumentException($"Tipo de entrada não suportado: {input.GetType()}", nameof(input))
            };
        }

        public ClienteOutputDto ToOutputDto()
        {
            return new ClienteOutputDto
            {
                Id = Id,
                Nome = Nome,
                Documento = Documento,
                Telefone = Telefone,
                Email = Email,
                DataCriacao = DataCriacao,
                DataNascimento = DataNascimento,
                Pedidos = Pedidos.Select(pedido => pedido.ToOutputDto()).ToList() ?? []
            };
        }
    }
}

