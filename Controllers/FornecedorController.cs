using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;
using static PIM.api.Enum.EnumSistemaFazenda;

namespace PIM.api.Controllers
{
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly FazendoDbContext _context;
        public FornecedorController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddNovoFornecedor(FonecedorInput NovoFornecedor)
        {
            _context.Fornecedor.Add(new FornecedorEntidade(NovoFornecedor.ID, NovoFornecedor.EmpresaID, NovoFornecedor.Nome, NovoFornecedor.CNPJ, NovoFornecedor.Telefone, NovoFornecedor.Email, NovoFornecedor.MunicipioID, true));
            _context.SaveChanges();
            
            return Created("Fornecedor criado", NovoFornecedor);
        }
        [HttpPut]
        public IActionResult AlterarFornecedor(Guid Acesso, FonecedorInput FornecedorUpdate)
        {
            //FornecedorUpdate.Empresa = null;
            //FornecedorUpdate.Municipio = null;

            var userCriando = _context.Colaboradores.FirstOrDefault(o => o.Usuario.Acesso == Acesso);
            if (userCriando == null) return BadRequest("Usuario não encontrado");

            if (userCriando.Funcao != (int)EnumTipoUsuario.Diretor && userCriando.Funcao != (int)EnumTipoUsuario.Coordenador)
                return Forbid("Usuario não pode criar fornecedor");

            var FornecedorAtual = _context.Fornecedor.FirstOrDefault(o => o.ID == FornecedorUpdate.ID);
            if (FornecedorAtual == null) return BadRequest("Fornecedor não encontrado");

            FornecedorAtual.CNPJ = FornecedorUpdate.CNPJ;
            FornecedorAtual.Nome = FornecedorUpdate.Nome;
            FornecedorAtual.Email = FornecedorUpdate.Email;
            FornecedorAtual.Telefone = FornecedorUpdate.Telefone;
            FornecedorAtual.MunicipioID = FornecedorUpdate.MunicipioID;

            _context.SaveChanges();
            return Ok("Fornecedor atualizado");
        }
        [HttpGet]
        public IActionResult GetFornecedor(Guid Acesso, int FornecedorID)
        {
            var userCriando = _context.Usuarios.FirstOrDefault(o => o.Acesso == Acesso);
            if (userCriando == null) return BadRequest("Usuario não encontrado");

            var Fornecedor = _context.Fornecedor.Include(o=> o.Municipio).Include(o=> o.Municipio.UF).FirstOrDefault(o=> o.ID == FornecedorID);
            if (userCriando == null) return BadRequest("Usuario não encontrado");

            return Ok(Fornecedor);
        }
        [HttpDelete]
        public IActionResult ApagarFornecedor(Guid Acesso, int FornecedorID)
        {
            var userCriando = _context.Colaboradores.FirstOrDefault(o => o.Usuario.Acesso == Acesso);
            if (userCriando == null) return BadRequest("Usuario não encontrado");

            if (userCriando.Funcao != (int)EnumTipoUsuario.Diretor || userCriando.Funcao != (int)EnumTipoUsuario.Coordenador)
                return Forbid("Usuario não pode apagar fornecedor");

            var FornecedorAlvo = _context.Fornecedor.FirstOrDefault(o => o.ID == FornecedorID);
            if (FornecedorAlvo == null) return BadRequest("Fornecedor não encontrado");

            FornecedorAlvo.Ativo = false;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("TodosFornecedores")]
        public IActionResult TodosFornecedor(Guid Acesso, int EmpresaID)
        {
            var userCriando = _context.Usuarios.FirstOrDefault(o => o.Acesso == Acesso);
            if (userCriando == null) return BadRequest("Usuario não encontrado");
            List < FornecedorEntidade > ListaFonecedores = _context.Fornecedor.Where(o=> o.EmpresaID == EmpresaID).Include(o=> o.Municipio).ToList();
            return Ok(ListaFonecedores);
        }
    }
}
