using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;

namespace PIM.api.Controllers
{
    [Route("api/SolcitacaoCompra")]
    [ApiController]
    public class SolcitacaoCompraMateriaPrimaController : ControllerBase
    {
        private readonly FazendoDbContext _context;
        public SolcitacaoCompraMateriaPrimaController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetSolcitacoes(int empresaID) {
            var empresa = _context.Empresa.SingleOrDefault(o => o.ID == empresaID);
            if (empresa == null) return BadRequest("Empresa não encontrada");
            var solcitacoes = _context.SolcitacaoCompraMateriaPrima.Include(o => o.UsuarioSolcitante).Where(o => o.UsuarioSolcitante.EmpresaID == empresa.ID).ToList();

            return Ok(solcitacoes);
        }
        [HttpGet("Unico")]
        public IActionResult GetSolcitacao(int solcitacaoID) {
            var solcitacao = _context.SolcitacaoCompraMateriaPrima.Include(o=> o.UsuarioSolcitante).SingleOrDefault(o=> o.ID == solcitacaoID);
            if (solcitacao == null) return BadRequest("Solcitação não encotrada");
            return Ok(solcitacao);
        }
        [HttpPost]
        public IActionResult PostSolcitacao(Guid Acesso, SolicitacaoMateriaPrimaInput SolicitacaoInput)
        {
            var solicitante = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (solicitante == null) return NotFound("Solicitante não encontrado");

            var solcitacao = SolicitacaoInput.Converter();
            solcitacao.UsuarioSolcitanteID = solicitante.ID;
            _context.SolcitacaoCompraMateriaPrima.Add(solcitacao);
            _context.SaveChanges();

            return Ok("Solicitação compra de materia prima criada");
        }
        [HttpPut]
        public IActionResult PutSolcitacao(Guid Acesso ,SolicitacaoMateriaPrimaInput SolicitacaoInput)
        {
            var solicitante = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (solicitante == null) return NotFound("Usuario não encontrado");
            var solicitacao = _context.SolcitacaoCompraMateriaPrima.SingleOrDefault(o => o.ID == SolicitacaoInput.ID);
            if (solicitacao == null) return NotFound("Solicitação não encontrada");

            solicitacao.Descricao = SolicitacaoInput.Descricao;
            solicitacao.Quantidade = SolicitacaoInput.Quantidade;
            solicitacao.UsuarioSolcitanteID = solicitante.ID;
            _context.SaveChanges();

            return Ok("Solicitacao atualizada");
        }
        [HttpDelete]
        public IActionResult DeleteSolcitacao(Guid Acesso ,int SolicitacaoID)
        {
            var solicitante = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (solicitante == null) return NotFound("Usuario não encontrado");
            var solicitacao = _context.SolcitacaoCompraMateriaPrima.Include(o=> o.UsuarioSolcitante).SingleOrDefault(o => o.ID == SolicitacaoID && o.UsuarioSolcitante.EmpresaID == solicitante.EmpresaID);
            if (solicitacao == null) return NotFound("Solicitação não encontrada");

            _context.SolcitacaoCompraMateriaPrima.Remove(solicitacao);
            _context.SaveChanges();

            return Ok("Solicitacao removida");
        }
    }
}
