using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class ProdutoService(IProdutoRepository repository) : IProdutoService
    {
        public async Task<Produto> CreateProdutoAsync(ProdutoCreateInputDto produtoCreate, CancellationToken cancellationToken = default)
            => await repository.CreateProdutoAsync(produtoCreate, cancellationToken);

        public async Task<List<Produto>> GetProdutoByNameAsync(string name, CancellationToken cancellationToken = default)
            => await repository.GetProdutoByNameAsync(name, cancellationToken);

        public async Task<List<Produto>> GetAllProdutosAsync(CancellationToken cancellationToken = default)
            => await repository.GetAllProdutosAsync(cancellationToken);

        public async Task<Produto?> GetProdutoByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.GetProdutoByIdAsync(id, cancellationToken);

        public async Task<Produto> UpdateProdutoAsync(Guid id, ProdutoUpdateInputDto updatedProduto, CancellationToken cancellationToken = default)
            => await repository.UpdateProdutoAsync(id, updatedProduto, cancellationToken);

        public async Task DeleteProdutoAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.DeleteProdutoAsync(id, cancellationToken);

        public async Task<long> GetProdutosCountAsync(CancellationToken cancellationToken = default)
            => await repository.GetProdutosCountAsync(cancellationToken);
    }
}
