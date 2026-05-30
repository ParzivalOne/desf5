using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class ProdutoService(WebStoreDBContext dBContext) : IProdutoService
    {
        public async Task<Produto> CreateProdutoAsync(ProdutoCreateInputDto produtoCreate, CancellationToken cancellationToken = default)
        {
            var produto = Produto.MapFrom(produtoCreate);
            produto.Id = Guid.NewGuid();
            dBContext.Produtos.Add(produto);
            await dBContext.SaveChangesAsync(cancellationToken);
            return produto;
        }

        public async Task<List<Produto>> GetAllProdutosAsync(CancellationToken cancellationToken = default)
        {
            return await dBContext.Produtos.ToListAsync(cancellationToken);
        }

        public async Task<Produto?> GetProdutoByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dBContext.Produtos.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<Produto> UpdateProdutoAsync(Guid id, ProdutoUpdateInputDto updatedProduto, CancellationToken cancellationToken = default)
        {
            var existingProduto = await dBContext.Produtos.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingProduto == null)
            {
                throw new KeyNotFoundException($"Produto with ID {id} not found.");
            }
            existingProduto.Nome = updatedProduto.Nome ?? existingProduto.Nome;
            existingProduto.Preco = updatedProduto.Preco ?? existingProduto.Preco;
            existingProduto.Descricao = updatedProduto.Descricao ?? existingProduto.Descricao;
            existingProduto.Estoque = updatedProduto.Estoque ?? existingProduto.Estoque;
            await dBContext.SaveChangesAsync(cancellationToken);
            return existingProduto;
        }

        public async Task DeleteProdutoAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var existingProduto = await dBContext.Produtos.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingProduto == null)
            {
                throw new KeyNotFoundException($"Produto with ID {id} not found.");
            }
            dBContext.Produtos.Remove(existingProduto);
            await dBContext.SaveChangesAsync(cancellationToken);
        }
    }
}
