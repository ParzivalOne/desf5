using WebStore.DTOs;

namespace WebStore.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public List<Pedido>? Pedidos { get; set; }
        public DateTime DataCriacao { get; set; }

        public static Produto MapFrom<T>(T input) where T : class
        {
            if (input is null) throw new ArgumentNullException(nameof(input));

            return input switch
            {
                ProdutoCreateInputDto c => new Produto
                {
                    Nome = c.Nome,
                    CodigoDeBarras = c.CodigoDeBarras,
                    Descricao = c.Descricao,
                    Estoque = c.Estoque,
                    Preco = c.Preco,
                    DataCriacao = DateTime.UtcNow
                },
                ProdutoUpdateInputDto u => new Produto
                {
                    Nome = u.Nome ?? string.Empty,
                    CodigoDeBarras = u.CodigoDeBarras ?? string.Empty,
                    Descricao = u.Descricao ?? string.Empty,
                    Preco= u.Preco ?? 0,
                    Estoque = u.Estoque ?? 0
                },
                Produto existing => existing,
                _ => throw new ArgumentException($"Tipo de entrada não suportado: {input.GetType()}", nameof(input))
            };

        }

        public ProdutoOutputDto ToOutputDto()
        {
            return new ProdutoOutputDto
            {
                Id = Id,
                Nome = Nome,
                CodigoDeBarras = CodigoDeBarras,
                Descricao = Descricao,
                Estoque = Estoque,
                DataCriacao = DataCriacao
            };
        }
    }
}
