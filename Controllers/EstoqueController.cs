using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;

namespace PIM.api.Controllers
{
    [Route("api/Estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly FazendoDbContext _context;
        public EstoqueController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Estoques(int empresaID)
        {
            bool empresaExiste = _context.Empresa.Any(o=> o.ID == empresaID);
            if (empresaExiste) return BadRequest("Empresa não encontrado");

            var listaEstoque = _context.Estoque.Include(o => o.Produto)
                .Where(o => o.Produto.Ativo && o.Produto.EmpresaID == empresaID).ToList();

            List<EstoqueView> listaProdutos = _context.Produto.Include(o => o.Fornecedor)
                .Where(o => o.EmpresaID == empresaID && o.Ativo).ToList()
                .Select(o=>
                {
                    int Quantidade = listaEstoque.Where(oo=> oo.ProdutoID == o.ID).Sum(oo=> oo.Quantidade);
                    return new EstoqueView
                    {
                        Quantidade = Quantidade == 0 ? "Não ha estoque" : Quantidade.ToString(),
                        ProdutoNome = o.Nome,
                        FornecedorNome = o.Fornecedor.Nome,
                        ValorKG = o.ValorVendaKG == null ? "Valor não cadastrado" : o.ValorVendaKG.Value.ToString()
                    };
                }).ToList();
            if (listaProdutos.Count == 0) return Ok(new List<EstoqueView>());

            return Ok(listaProdutos);
        }
        [HttpGet]
        public IActionResult Estoque(int produtoID)
        {
            var produtos = _context.Produto.Include(o => o.Fornecedor)
                .SingleOrDefault(o => o.ID == produtoID);
            if (produtos == null) return BadRequest("Produto não encontrado");

            var listaEstoque = _context.Estoque.Include(o => o.Produto)
                .Where(o => o.Produto.ID == produtoID).ToList();

            int Quantidade = listaEstoque.Where(o => o.ProdutoID == produtoID).Sum(o => o.Quantidade);
            var Estoque = new EstoqueView
            {
                Quantidade = Quantidade == 0 ? "Não ha estoque" : Quantidade.ToString(),
                ProdutoNome = produtos.Nome,
                FornecedorNome = produtos.Fornecedor.Nome,
                ValorKG = produtos.ValorVendaKG == null ? "Valor não cadastrado" : produtos.ValorVendaKG.Value.ToString()
            };

            return Ok(Estoque);
        }
    }
}
