using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;
using static PIM.api.Enum.EnumSistemaFazenda;

namespace PIM.api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly FazendoDbContext _context;
        public UsuarioController(FazendoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddNovoUsuario(Guid Acesso, UsuarioEntidade NovoUsuario)
        {
            var Permissao = PossuiPermissao(Acesso);

            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            int empresaID = _context.Usuarios.Single(o => o.Acesso == Acesso).EmpresaID;
            NovoUsuario.Empresa = null;
            NovoUsuario.EmpresaID = empresaID;

            _context.Usuarios.Add(NovoUsuario);
            _context.SaveChanges();

            return Created("Usuario criado", NovoUsuario);
        }
        [HttpPut]
        public IActionResult AlterarUsuario(Guid Acesso, UsuarioEntidade UsuarioUpdade)
        {
            UsuarioUpdade.Empresa = null;

            var usuarioAlterando = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (usuarioAlterando == null) return BadRequest("Acesso não encontrado");
            var Permissao = PossuiPermissao(Acesso);
            if (!Permissao.PossuiPermissao && usuarioAlterando.ID != UsuarioUpdade.ID)
                return Forbid(Permissao.Mensagem);

            var UserAlvo = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (UserAlvo == null) return BadRequest("Usuario a ser atualizado não encontrado");

            UserAlvo.Acesso = null;
            UserAlvo.Nome = UsuarioUpdade.Nome;
            UserAlvo.Login = UsuarioUpdade.Login;
            UserAlvo.Senha = UsuarioUpdade.Senha;
            UserAlvo.Telefone = UsuarioUpdade.Telefone;
            UserAlvo.Funcao = UsuarioUpdade.Funcao;
            _context.SaveChanges();

            return Ok("Usuario alterado");
        }
        [HttpGet]
        public IActionResult ListaUsuarios(Guid Acesso, bool UsuariosAtivos)
        {
            var User = _context.Usuarios.SingleOrDefault(o => o.Acesso == Acesso);
            if (User == null) return BadRequest("Usuario não encontrado: " + Acesso);

            List<PermissaoEditarUser> ListaUsuarios = permissaoEditarUsers(User.EmpresaID, (EnumTipoUsuario)User.Funcao, User.ID, UsuariosAtivos);

            return Ok(ListaUsuarios);
        }
        [HttpGet("Unico")]
        public IActionResult UsuarioUnico(int ID)
        {
            var User = _context.Usuarios.SingleOrDefault(o => o.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            User.Senha = "";
            User.Acesso = null;
            User.Empresa = null;
            return Ok(User);
        }
        [HttpDelete]
        public IActionResult InativarUser(Guid Acesso, int ID)
        {
            var User = _context.Usuarios.SingleOrDefault(o=> o.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            var UserAcesso = _context.Usuarios.SingleOrDefault(o=> o.ID == ID);
            if (UserAcesso == null) return BadRequest("Usuario editando não entrado: " + Acesso);


            bool possuiPermissaão =
                            UserAcesso.Funcao == (int)EnumTipoUsuario.Diretor
                        || (UserAcesso.Funcao == (int)EnumTipoUsuario.Coordenador && User.Funcao == (int)EnumTipoUsuario.Produtor)
                        || User.ID == UserAcesso.ID;
            if (UserAcesso.Funcao != (int)EnumTipoUsuario.Diretor) return Forbid("Usuario editando não possui acesso suficiente");

            User.Ativo = false;
            User.Senha = "";
            _context.SaveChanges();
            return Ok("Inativado");
        }



        private List< PermissaoEditarUser > permissaoEditarUsers(int EmpresaID, EnumTipoUsuario TipoUsuario, int UsuarioEditandoID, bool Ativo)
        {
            var ListaUsuarios = _context.Usuarios
                .Where(o=> o.EmpresaID == EmpresaID && o.Ativo == Ativo).ToList()
                .Select(o=>
                {
                    bool PodeEditar = false;

                    PodeEditar = 
                            TipoUsuario == EnumTipoUsuario.Diretor
                        || (TipoUsuario == EnumTipoUsuario.Coordenador && o.Funcao == (int)EnumTipoUsuario.Produtor)
                        ||  UsuarioEditandoID == o.ID;

                    return new PermissaoEditarUser
                    {
                        PodeEditar = PodeEditar,
                        Nome = o.Nome,
                        Login = PodeEditar? o.Login : "",
                        Ativo = o.Ativo,
                        Telefone = o.Telefone,
                        Funcao = o.Funcao
                    };
                }).ToList();

                
                




            return ListaUsuarios;
        }

        private (bool Existe, bool PossuiPermissao, string Mensagem) PossuiPermissao(Guid acesso)
        {
            var User = _context.Usuarios.SingleOrDefault(o => o.Acesso == acesso);
            bool Existe = User != null;
            bool UsuarioPermitido = false;
            string Mensagem = "";

            if (!Existe)
                return (Existe: Existe, PossuiPermissao: false, Mensagem: "Acesso não encontrado");

            UsuarioPermitido = (byte)User.Funcao == (byte)EnumTipoUsuario.Diretor;

            if (!UsuarioPermitido)
                Mensagem = "Usuario não possui direiro de acesso sufuciente";

            return (Existe: Existe, PossuiPermissao: UsuarioPermitido, Mensagem: Mensagem);
        }

    }
}
