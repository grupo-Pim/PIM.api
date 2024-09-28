using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static PIM.api.Enum.EnumSistemaFazenda;

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
            bool PossuiEmpresa = _context.Empresa.Any(o => o.CNPJ == Empresa.CNPJ);
            if (PossuiEmpresa) return BadRequest("Ja possui empresa com esse cnpj");
            Empresa.Municipio = null;

            _context.Empresa.Add(Empresa);
            _context.SaveChanges();

            int EmpresaID = _context.Empresa.Single(o=> o.CNPJ.Equals(Empresa.CNPJ)).ID;
            var UsuarioPadrao = new ColaboradorEntidade();

            UsuarioPadrao.Funcao = (int)EnumTipoUsuario.Diretor;
            UsuarioPadrao.Usuario = new UsuarioEntidade();
            UsuarioPadrao.Usuario.SerColaborador = true;
            UsuarioPadrao.Usuario.Nome = "Admin";
            UsuarioPadrao.Usuario.Login = "Admin";
            UsuarioPadrao.Usuario.Senha = "Admin_" + Empresa.Nome;
            UsuarioPadrao.Usuario.EmpresaID = EmpresaID;

            _context.Colaboradores.Add(UsuarioPadrao);
            _context.SaveChanges();

            return Created("Empresa Criada", Empresa);
        }
        [HttpPut]
        public IActionResult AlteraEmpresa(Guid Acesso, EmpresaEntidade EmpresaUpdate)
        {
            var Permissao = PossuiPermissao(Acesso);
            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            var empresaAlvo = _context.Empresas.SingleOrDefault(o => o.ID == EmpresaUpdate.ID);
            if (empresaAlvo == null) return BadRequest("Empresa não encontada");

            empresaAlvo.Ativo = true;
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
        public IActionResult DadosEmpresaID(Guid Acesso, int EmpresaID)
        {
            var Permissao = PossuiPermissao(Acesso);

            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            var empresa = _context.Empresa.SingleOrDefault(o => o.ID == EmpresaID);
            if (empresa == null) return BadRequest("Empresa não encontrada: " + EmpresaID);

            return Ok(empresa);
        }
        [HttpDelete]
        public IActionResult ApagarEmpresa(Guid Acesso, int EmpresaID)
        {
            var Permissao = PossuiPermissao(Acesso);

            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            var Empresa = _context.Empresa.SingleOrDefault(o => o.ID == EmpresaID);
            if (Empresa == null) return NotFound("Empresa não encontrada: " + EmpresaID);
            Empresa.Ativo = false;
            return Ok("Empresa inativada");
        }


        private (bool Existe, bool PossuiPermissao, string Mensagem) PossuiPermissao(Guid acesso)
        {
            var User = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == acesso);
            bool Existe = User != null;
            bool UsuarioPermitido = false;
            string Mensagem = "";

            if (!Existe)
                return (Existe: Existe, PossuiPermissao: false, Mensagem: "Acesso não encontrado");

            UsuarioPermitido = (byte)User.Funcao == (byte)EnumTipoUsuario.Diretor;

            if (!UsuarioPermitido)
                Mensagem = "Usuario não possui direiro de alterar empresa";

            return (Existe: Existe, PossuiPermissao: UsuarioPermitido, Mensagem: Mensagem);
        }

    }
}

