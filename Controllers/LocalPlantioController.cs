using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;
using static PIM.api.Enum.EnumSistemaFazenda;

namespace PIM.api.Controllers
{
    [Route("api/local")]
    [ApiController]
    public class LocalPlantioController : Controller
    {
        private readonly FazendoDbContext _context;
        public LocalPlantioController(FazendoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult NovoLocal(Guid acesso, LocalPlantioEntidade NovoLocal)
        {
            NovoLocal.Empresa = null;
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");

            _context.LocalPlantio.Add(NovoLocal);
            _context.SaveChanges();
            return Created("Local criado", NovoLocal);
        }
        [HttpGet]
        public IActionResult GetListaLocal(int EmpresaID)
        {
            bool EmpresaExiste = _context.Empresa.Any(o=> o.ID == EmpresaID);
            if (EmpresaExiste) return NotFound("Empresa não econtrada: "+ EmpresaID);

            List<LocalPlantioEntidade> ListaLocalPlantio = _context.LocalPlantio.Where(o=> o.EmpresaID == EmpresaID).ToList();
            return Ok(ListaLocalPlantio);
        }
        [HttpGet("Unico")]
        public IActionResult GetLocal(int LocalID)
        {
            var LocalAlvo = _context.LocalPlantio.FirstOrDefault(o => o.ID == LocalID);
            if (LocalAlvo == null) return NotFound("Local não encontrado: " + LocalID);

            return Ok(LocalAlvo); 
        }
        [HttpPut]
        public IActionResult AlterarLocal(Guid acesso, LocalPlantioEntidade LocalUpdate)
        {
            LocalUpdate.Empresa = null;
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");

            var localAlvo = _context.LocalPlantio.SingleOrDefault(o=> o.ID == LocalUpdate.ID);
            if (localAlvo == null) return NotFound("Local não encontrado: "+ LocalUpdate.ID);

            localAlvo.Tamanho = LocalUpdate.Tamanho;
            localAlvo.Localizacao = LocalUpdate.Localizacao;
            localAlvo.Nome = LocalUpdate.Nome;
            _context.SaveChanges();

            return Ok("Local atualizado");
        }
        [HttpDelete]
        public IActionResult ApagarLocal(Guid acesso, int LocalID)
        {
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");

            var localAlvo = _context.LocalPlantio.SingleOrDefault(o=> o.ID == LocalID);
            if (localAlvo == null) return NotFound("Local não existe: "+ LocalID);
            localAlvo.Ativo = false;
            _context.SaveChanges();

            return Ok("Local inativado");
        }

        private (bool possuiPermissao, bool existe, string Mensagem) userPossuiPermissao(Guid acesso)
        {
            var user = _context.Colaboradores.FirstOrDefault(o => o.Usuario.Acesso == acesso);
            if (user == null) return (possuiPermissao: false, existe: false, Mensagem: "Usuario não existe");

            if (user.Funcao == (int)EnumTipoUsuario.Produtor) return (possuiPermissao: false, existe: true, Mensagem: "Usuario não possui permissão");

            return (possuiPermissao: true, existe: true, Mensagem: "");
        }
    }
}
