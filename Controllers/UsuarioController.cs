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

        [HttpPost("Colaboradores")]
        public IActionResult AddNovoUsuario(Guid Acesso, ColaboradorEntidade NovoUsuario)
        {
            var Permissao = PossuiPermissao(Acesso);

            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            int empresaID = _context.Colaboradores.Single(o => o.Usuario.Acesso == Acesso).Usuario.EmpresaID;
            NovoUsuario.Usuario.Empresa = null;
            NovoUsuario.Usuario.EmpresaID = empresaID;

            _context.Colaboradores.Add(NovoUsuario);
            _context.SaveChanges();

            return Created("Usuario criado", NovoUsuario);
        }
        [HttpPut("Colaboradores")]
        public IActionResult AlterarUsuario(Guid Acesso, ColaboradorEntidade UsuarioUpdade)
        {
            UsuarioUpdade.Usuario.Empresa = null;

            var usuarioAlterando = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (usuarioAlterando == null) return BadRequest("Acesso não encontrado");
            var Permissao = PossuiPermissao(Acesso);
            if (!Permissao.PossuiPermissao && usuarioAlterando.Usuario.ID != UsuarioUpdade.Usuario.ID)
                return Forbid(Permissao.Mensagem);

            var UserAlvo = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (UserAlvo == null) return BadRequest("Usuario a ser atualizado não encontrado");

            UserAlvo.Usuario.Acesso = null;
            UserAlvo.Usuario.Nome = UsuarioUpdade.Usuario.Nome;
            UserAlvo.Usuario.Login = UsuarioUpdade.Usuario.Login;
            UserAlvo.Usuario.Senha = UsuarioUpdade.Usuario.Senha;
            UserAlvo.Usuario.Telefone = UsuarioUpdade.Usuario.Telefone;
            UserAlvo.Funcao = UsuarioUpdade.Funcao;
            _context.SaveChanges();

            return Ok("Usuario alterado");
        }
        [HttpGet("Colaboradores/Listar")]
        public IActionResult ListaUsuarios(Guid Acesso, bool UsuariosAtivos)
        {
            var User = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (User == null) return BadRequest("Usuario não encontrado: " + Acesso);


            UsuarioEntidade usuario = _context.Usuarios.Single(o => o.ID == User.UsuarioID);
            List<PermissaoEditarUser> ListaUsuarios = permissaoEditarUsers(usuario.EmpresaID, (EnumTipoUsuario)User.Funcao, usuario.ID, UsuariosAtivos);

            return Ok(ListaUsuarios);
        }
        [HttpGet("Colaboradores/Unico")]
        public IActionResult UsuarioUnico(int ID)
        {
            var User = _context.Colaboradores.SingleOrDefault(o => o.Usuario.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            User.Usuario.Senha = "";
            User.Usuario.Acesso = null;
            User.Usuario.Empresa = null;
            return Ok(User);
        }
        [HttpGet("Login")]
        public IActionResult UsuarioLogin(string login, string senha)
        {
            var User = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Login == login && o.Usuario.Senha == senha);
            if (User == null) return BadRequest("Usuario não entrado");

            UsuarioEntidade usuario = _context.Usuarios.Single(o => o.ID == User.UsuarioID);

            usuario.Acesso = Guid.NewGuid();
            _context.SaveChanges();
            usuario.Senha = "";
            return Ok(usuario);
        }
        [HttpDelete("Colaboradores")]
        public IActionResult InativarUser(Guid Acesso, int ID)
        {
            var User = _context.Colaboradores.SingleOrDefault(o=> o.Usuario.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            var UserAcesso = _context.Colaboradores.SingleOrDefault(o=> o.Usuario.ID == ID);
            if (UserAcesso == null) return BadRequest("Usuario editando não entrado: " + Acesso);


            bool possuiPermissaão =
                            UserAcesso.Funcao == (int)EnumTipoUsuario.Diretor
                        || (UserAcesso.Funcao == (int)EnumTipoUsuario.Coordenador && User.Funcao == (int)EnumTipoUsuario.Produtor)
                        || User.Usuario.ID == UserAcesso.Usuario.ID;
            if (UserAcesso.Funcao != (int)EnumTipoUsuario.Diretor) return Forbid("Usuario editando não possui acesso suficiente");

            User.Usuario.Ativo = false;
            User.Usuario.Senha = "";
            _context.SaveChanges();
            return Ok("Inativado");
        }


        [HttpPost("Cliente")]
        public IActionResult AddNovoCliente(Guid AcessoColaborador, ClienteEntidade NovoCliente)
        {
            var Permissao = PossuiPermissao(AcessoColaborador);

            if (!Permissao.Existe)
                return BadRequest(Permissao.Mensagem);
            else if (!Permissao.PossuiPermissao)
                return Forbid(Permissao.Mensagem);

            int empresaID = _context.Clientes.Single(o => o.Usuario.Acesso == AcessoColaborador).Usuario.EmpresaID;
            NovoCliente.Usuario.Empresa = null;
            NovoCliente.Usuario.EmpresaID = empresaID;

            _context.Clientes.Add(NovoCliente);
            _context.SaveChanges();

            return Created("Usuario criado", NovoCliente);
        }
        [HttpPut("Cliente")]
        public IActionResult AlterarCliente(Guid Acesso, ClienteEntidade ClienteUpdade, bool serColaborador)
        {
            ClienteUpdade.Usuario.Empresa = null;

            if (serColaborador)
            {
                var usuarioAlterando = _context.Clientes.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
                if (usuarioAlterando == null) return BadRequest("Acesso não encontrado");
                var Permissao = PossuiPermissao(Acesso);
                if (!Permissao.PossuiPermissao && usuarioAlterando.Usuario.ID != ClienteUpdade.Usuario.ID)
                    return Forbid(Permissao.Mensagem);
            }
            else
            {
                var usuarioAlterando = _context.Clientes.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
                if (usuarioAlterando == null || usuarioAlterando.Usuario.ID != ClienteUpdade.Usuario.ID) 
                    return Forbid("Não permitido ou não encontrado");
            }

            var UserAlvo = _context.Clientes.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (UserAlvo == null) return BadRequest("Usuario a ser atualizado não encontrado");

            UserAlvo.Usuario.Acesso = null;
            UserAlvo.Usuario.Nome = ClienteUpdade.Usuario.Nome;
            UserAlvo.Usuario.Login = ClienteUpdade.Usuario.Login;
            UserAlvo.Usuario.Senha = ClienteUpdade.Usuario.Senha;
            UserAlvo.Usuario.Telefone = ClienteUpdade.Usuario.Telefone;
            _context.SaveChanges();

            return Ok("Usuario alterado");
        }
        [HttpGet("Cliente/Listar")]
        public IActionResult ListaCliente(Guid AcessoColaborador, bool UsuariosAtivos)
        {
            var User = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == AcessoColaborador);
            if (User == null) return BadRequest("Usuario não encontrado: " + AcessoColaborador);

            UsuarioEntidade usuario = _context.Usuarios.Single(o => o.ID == User.UsuarioID);
            List<PermissaoEditarUser> ListaUsuarios = permissaoEditarCliente(usuario.EmpresaID, (EnumTipoUsuario)User.Funcao, UsuariosAtivos);
            
            return Ok(ListaUsuarios);
        }
        [HttpGet("Cliente/Unico")]
        public IActionResult UsuarioCliente(int ID)
        {
            var User = _context.Clientes.SingleOrDefault(o => o.Usuario.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            User.Usuario.Senha = "";
            User.Usuario.Acesso = null;
            User.Usuario.Empresa = null;
            return Ok(User);
        }
        [HttpDelete("Cliente")]
        public IActionResult InativarCliente(Guid Acesso, int ID)
        {
            var User = _context.Clientes.SingleOrDefault(o=> o.Usuario.ID == ID);
            if (User == null) return BadRequest("Usuario não entrado: " + ID);
            var UserAcesso = _context.Colaboradores.SingleOrDefault(o=> o.Usuario.ID == ID);
            if (UserAcesso == null) return BadRequest("Usuario editando não entrado: " + Acesso);

            bool possuiPermissaão =
                            UserAcesso.Funcao == (int)EnumTipoUsuario.Diretor
                        || UserAcesso.Funcao == (int)EnumTipoUsuario.Coordenador;
            if (UserAcesso.Funcao != (int)EnumTipoUsuario.Diretor) return Forbid("Usuario editando não possui acesso suficiente");

            User.Usuario.Ativo = false;
            User.Usuario.Senha = "";
            _context.SaveChanges();
            return Ok("Inativado");
        }


        private List< PermissaoEditarUser > permissaoEditarUsers(int EmpresaID, EnumTipoUsuario TipoUsuario, int UsuarioEditandoID, bool Ativo)
        {
            var ListaUsuarios = _context.Colaboradores
                .Where(o=> o.Usuario.EmpresaID == EmpresaID && o.Usuario.Ativo == Ativo).ToList()
                .Select(o=>
                {
                    bool PodeEditar = false;

                    PodeEditar = 
                            TipoUsuario == EnumTipoUsuario.Diretor
                        || (TipoUsuario == EnumTipoUsuario.Coordenador && o.Funcao == (int)EnumTipoUsuario.Produtor)
                        ||  UsuarioEditandoID == o.Usuario.ID;

                    return new PermissaoEditarUser
                    {
                        PodeEditar = PodeEditar,
                        Nome = o.Usuario.Nome,
                        Login = PodeEditar? o.Usuario.Login : "",
                        Ativo = o.Usuario.Ativo,
                        Telefone = o.Usuario.Telefone,
                        Funcao = o.Funcao
                    };
                }).ToList();

            return ListaUsuarios;
        }

        private List< PermissaoEditarUser > permissaoEditarCliente(int EmpresaID, EnumTipoUsuario TipoUsuario, bool Ativo)
        {
            bool PodeEditar = TipoUsuario == EnumTipoUsuario.Diretor || TipoUsuario == EnumTipoUsuario.Coordenador;

            var ListaUsuarios = _context.Clientes
                .Where(o=> o.Usuario.EmpresaID == EmpresaID && o.Usuario.Ativo == Ativo).ToList()
                .Select(o=>
                {
                    return new PermissaoEditarUser
                    {
                        PodeEditar = PodeEditar,
                        Nome = o.Usuario.Nome,
                        Login = PodeEditar? o.Usuario.Login : "",
                        Ativo = o.Usuario.Ativo,
                        Telefone = o.Usuario.Telefone
                    };
                }).ToList();

            return ListaUsuarios;
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
                Mensagem = "Usuario não possui direiro de acesso sufuciente";

            return (Existe: Existe, PossuiPermissao: UsuarioPermitido, Mensagem: Mensagem);
        }

    }
}
