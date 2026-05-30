using WebStore.DTOs;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> CreateProdutoAsync(ProdutoCreateInputDto produtoCreate, CancellationToken cancellationToken = default);
        Task DeleteProdutoAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Produto>> GetAllProdutosAsync(CancellationToken cancellationToken = default);
        Task<Produto?> GetProdutoByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Produto> UpdateProdutoAsync(Guid id, ProdutoUpdateInputDto updatedProduto, CancellationToken cancellationToken = default);
    }
}