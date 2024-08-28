using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace PIM.api.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly FazendoDbContext _context;

        public EmpresaController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddNovaEmpresa(EmpresaEntidade Empresa)
        {
            bool PossuiEmpresa = _context.Empresa.Where(o=> o.CNPJ== Empresa.CNPJ).Any();
            if (PossuiEmpresa) return BadRequest("Ja possui empresa com esse cnpj");
            Empresa.Municipio = null;

            _context.Empresas.Add(Empresa);
            _context.SaveChanges();
            return Created("Empresa Criada", Empresa);
        }
        [HttpPut]
        public IActionResult AlteraEmpresa(EmpresaEntidade EmpresaUpdate)
        {
            var empresaAlvo = _context.Empresas.SingleOrDefault(o=> o.ID == EmpresaUpdate.ID);
            if (empresaAlvo == null) return BadRequest("Empresa não encontada");

            empresaAlvo.Ativo = EmpresaUpdate.Ativo;
            empresaAlvo.Nome = EmpresaUpdate.Nome;
            empresaAlvo.CNPJ = EmpresaUpdate.CNPJ;
            empresaAlvo.RazaoSocial = EmpresaUpdate.RazaoSocial;
            empresaAlvo.Email = EmpresaUpdate.Email;
            empresaAlvo.Telefone = EmpresaUpdate.Telefone;
            empresaAlvo.TipoEmpresa = EmpresaUpdate.TipoEmpresa;
            empresaAlvo.PossuiFilial = EmpresaUpdate.PossuiFilial;
            empresaAlvo.Rua = EmpresaUpdate.Rua;
            empresaAlvo.Numero = EmpresaUpdate.Numero;
            empresaAlvo.Cep = EmpresaUpdate.Cep;
            empresaAlvo.MunicipioID = EmpresaUpdate.MunicipioID;

            _context.SaveChanges();
            return Ok("Empresa atualizada");
        }
        [HttpGet]
        public IActionResult DadosEmpresaID(int EmpresaID)
        {
            var empresa = _context.Empresa.SingleOrDefault(o=> o.ID == EmpresaID);
            if (empresa == null) return BadRequest("Empresa não encontrada: " + EmpresaID);

            return Ok(empresa);
        }
        [HttpDelete]
        public IActionResult ApagarEmpresa(int EmpresaID)
        {
            var Empresa = _context.Empresa.SingleOrDefault(o=> o.ID==EmpresaID);
            if(Empresa == null) return NotFound("Empresa não encontrada: "+ EmpresaID);
            Empresa.Ativo = false;
            return Ok("Empresa inativada");
        }

    }
}

