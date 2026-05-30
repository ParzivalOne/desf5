using WebStore.DTOs;
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

        public static Pedido MapFrom<T>(T input) where T : class
        {
            if (input is null) throw new ArgumentNullException(nameof(input));

            return input switch
            {
                PedidoCreateInputDto p => new Pedido
                {
                    ClienteId = p.ClienteId,
                    ItensPedido = p.ItensPedido?.Select(i => new ItemPedido
                    {
                        ProdutoId = i.ProdutoId,
                        Quantidade = i.Quantidade
                    }).ToList() ?? new List<ItemPedido>(),
                    EnderecoEntrega = p.EnderecoEntrega,
                    Status = p.Status,
                    DataCriacao = DateTime.UtcNow
                },
                PedidoUpdateInputDto u => new Pedido
                {
                    EnderecoEntrega = u.EnderecoEntrega ?? string.Empty,
                    Status = u.Status ?? EStatusPedido.Criado
                },
                Pedido existing => existing,
                _ => throw new ArgumentException($"Tipo de entrada não suportado: {input.GetType()}", nameof(input))
            };
        }

        public PedidoOutputDto ToOutputDto()
        {
            return new PedidoOutputDto
            {
                Id = Id,
                ClienteId = ClienteId,
                ItensPedido = ItensPedido?.Select(i => i.ToOutputDto()).ToList() ?? [],
                EnderecoEntrega = EnderecoEntrega,
                Status = Status,
                DataCriacao = DataCriacao
            };
        }
    }
}
