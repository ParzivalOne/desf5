namespace WebStore.DTOs
{
    public class ProdutoCreateInputDto
    {
        public string Nome { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
