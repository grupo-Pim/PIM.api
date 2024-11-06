using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;
using System.Security.Cryptography;

namespace PIM.api.Controllers
{
    [Route("api/RelatorioVendas")]
    [ApiController]
    public class RelatorioVendaController : ControllerBase
    {
        private readonly FazendoDbContext _context;
        public RelatorioVendaController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult RelatorioVenda(Guid Acesso, RelatorioInput RelatorioInput)
        {
            var usuarioExiste = _context.Usuarios.SingleOrDefault(o=> o.Acesso == Acesso);
            if (usuarioExiste == null) return NotFound("Usuario não encontrado");

            var listaProdutosVendidos = _context.Pedidos.Include(o=> o.Produto)
                .Where(o => o.EmpresaID == usuarioExiste.EmpresaID 
                    && (o.ProdutoID == RelatorioInput.ProdutoID || !RelatorioInput.ProdutoID.HasValue )
                    && (o.UsuarioID == RelatorioInput.UsuarioID || !RelatorioInput.UsuarioID.HasValue )
                    && (o.DtPedido.Date >= RelatorioInput.DtInicio.Date) 
                    && (o.DtPedido.Date <= RelatorioInput.DtFim.Date)).ToList();

            List<RelatorioDiario> Diario = new();
            for (DateTime i = RelatorioInput.DtInicio.Date; i <= RelatorioInput.DtFim.Date; i = i.AddDays(1))
            {
                Diario.Add(new RelatorioDiario
                {
                    dia = i,
                    ValorVenda = (float)listaProdutosVendidos.Where(o => o.DtPedido.Date == i).Sum(o => o.Quantidade * o.Produto.ValorVendaKG),
                    QntProdutoVendido = listaProdutosVendidos.Where(o => o.DtPedido.Date == i).Sum(o => o.Quantidade),
                });
            }


            RelatorioVenda RelatorioVenda = new RelatorioVenda()
            {
                DtFim = RelatorioInput.DtFim,
                DtInicio = RelatorioInput.DtInicio,
                ProdutoID = RelatorioInput.ProdutoID,
                Diario = Diario,
                Produto = RelatorioInput.ProdutoID.HasValue ? _context.Produto.FirstOrDefault(o=> o.ID == RelatorioInput.ProdutoID) : null,
                UsuarioID = RelatorioInput.UsuarioID,
                QntProdutoVendido = listaProdutosVendidos.Sum(o=> o.Quantidade),
                ValorVenda = (float)listaProdutosVendidos.Sum(o=> o.Quantidade * o.Produto.ValorVendaKG),
            };
            return Ok(RelatorioVenda);
        }
    }
}
