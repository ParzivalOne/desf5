using Microsoft.AspNetCore.Mvc;
using WebStore.DTOs;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController(IProdutoService produtoService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ProdutoOutputDto?> GetProdutoByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var produto = await produtoService.GetProdutoByIdAsync(id, cancellationToken);
            return produto?.ToOutputDto();
        }

        [HttpGet("nome/{name}")]
        public async Task<List<ProdutoOutputDto>> GetProdutosByNameAsync([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var produtos = await produtoService.GetProdutoByNameAsync(name, cancellationToken);
            return produtos.Select(produto => produto.ToOutputDto()).ToList();
        }

        [HttpGet]
        public async Task<List<ProdutoOutputDto>> GetAllProdutosAsync(CancellationToken cancellationToken = default)
        {
            var produtos = await produtoService.GetAllProdutosAsync(cancellationToken);
            return produtos.Select(produto => produto.ToOutputDto()).ToList();
        }

        [HttpGet("count")]
        public async Task<long> GetProdutosCountAsync(CancellationToken cancellationToken = default)
        {
            return await produtoService.GetProdutosCountAsync(cancellationToken);
        }

        [HttpPost]
        public async Task<ProdutoOutputDto> CreateProdutoAsync([FromBody] ProdutoCreateInputDto produto, CancellationToken cancellationToken = default)
        {
            var createdProduto = await produtoService.CreateProdutoAsync(produto, cancellationToken);
            return createdProduto.ToOutputDto();
        }

        [HttpPatch("{id}")]
        public async Task<ProdutoOutputDto> UpdateProdutoAsync([FromRoute] Guid id, [FromBody] ProdutoUpdateInputDto updatedProduto, CancellationToken cancellationToken = default)
        {
            var produto = await produtoService.UpdateProdutoAsync(id, updatedProduto, cancellationToken);
            return produto.ToOutputDto();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProdutoAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            await produtoService.DeleteProdutoAsync(id, cancellationToken);
        }
    }
}
