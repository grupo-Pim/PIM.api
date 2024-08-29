using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;

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
        public IActionResult AddNovoUsuario(EmpresaEntidade Empresa)
        {

        }
    }
}
