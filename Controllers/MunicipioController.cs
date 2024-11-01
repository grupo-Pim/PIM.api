using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.api.Entidades;
using PIM.api.Persistence;
namespace PIM.api.Controllers
{
    [Route("api/Municipio_Estado")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly FazendoDbContext _context;
        public MunicipioController(FazendoDbContext context)
        {
            _context = context;
        }
        [HttpGet("Municipios")]
        public IActionResult GetMunicipio(int EstadoID)
        {
            bool estadoExiste = _context.Estados.Any(o=> o.ID == EstadoID);
            if (!estadoExiste) return BadRequest("Estado id não existe: "+ EstadoID);
            List<MunicipioEntidade> ListaMunicipio = _context.Municipios.Include(o=> o.UF).Where(o=> o.UFID == EstadoID).ToList();
            return Ok(ListaMunicipio);
        }
        [HttpGet("Estado")]
        public IActionResult GetEstado()
        {
            List<EstadoEntidade> ListaEstado = _context.Estados.ToList();
            return Ok(ListaEstado);
        }
        [HttpGet("BuscarMunicipios")]
        public IActionResult BuscarMunicipio(int MunicipioID)
        {
            bool estadoExiste = _context.Municipios.Any(o => o.ID == MunicipioID);
            if (!estadoExiste) return BadRequest("Municipio id não existe: " + MunicipioID);
            MunicipioEntidade Municipio = _context.Municipios.Include(o=> o.UF).FirstOrDefault(o => o.ID == MunicipioID);
            return Ok(Municipio);
        }


    }
}
