using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;

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
            _context.Empresas.Add(Empresa);
            //_context.SaveChanges();
            return Created("Empresa Criada", Empresa);
        }
        [HttpPut]
        public IActionResult AlteraEmpresa(EmpresaEntidade EmpresaUpdate)
        {
            return Ok("teste");
        }




    }
}

