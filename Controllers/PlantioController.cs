using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;
using static PIM.api.Enum.EnumSistemaFazenda;

namespace PIM.api.Controllers
{
    [Route("api/plantio")]
    [ApiController]
    public class PlantioController : ControllerBase
    {
        private readonly FazendoDbContext _context;
        public PlantioController(FazendoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddNovoPlantio(Guid Acesso, PlantioEntidade NovoPlantio)
        {
            NovoPlantio.Empresa = null;
            NovoPlantio.Local = null;
            
            var colaborador = _context.Colaboradores.SingleOrDefault(o=> o.Usuario.Acesso == Acesso);
            if (colaborador == null) return BadRequest("Acesso não encontrado");
            var local = _context.LocalPlantio.SingleOrDefault(o=> o.ID == NovoPlantio.LocalID);
            if (local == null) return BadRequest("Local não encontrado");
            if (local.EmpresaID != colaborador.Usuario.EmpresaID) return BadRequest("Usuario não é da mesma empresa do plantio");

            var possuiPlantioNoLocal = _context.Plantio.Where(o=> o.LocalID == local.ID && !o.DataColheita.HasValue && o.Etapa != (byte)EnumEtapaPlantio.Danificado);

            if (possuiPlantioNoLocal.Count() > 0)
            {
                return Conflict(
                    new
                    {
                        message = string.Format("Já existe uma plantação de {0} no local, com data de plantio em {1}.", possuiPlantioNoLocal.First().Produto.Nome, possuiPlantioNoLocal.First().DataPlantio.ToString("dd/MM/yyyy"))
                    }
                );
            }

            _context.Plantio.Add(NovoPlantio);
            _context.SaveChanges();
            
            return Created("Criado: ", NovoPlantio);
        }
        [HttpPut]
        public IActionResult AtualizacaoPlantio(Guid Acesso, int PlantioID, byte statusPlantio)
        {
            var colaborador = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (colaborador == null) return BadRequest("Acesso não encontrado");
            var Plantio = _context.Plantio.SingleOrDefault(o => o.ID == PlantioID);
            if (Plantio == null) return BadRequest("Plantio não encontrado");
            if (Plantio.EmpresaID != colaborador.Usuario.EmpresaID) return BadRequest("Usuario não é da mesma empresa do plantio");

            MovimentacoesPlantioEntidade UpdatePlantio = new MovimentacoesPlantioEntidade(PlantioID, DateTime.Now, statusPlantio, Plantio.Etapa, colaborador.ID);
            _context.MovimentacoesPlantio.Add(UpdatePlantio);
            Plantio.Etapa = statusPlantio;
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("Unico")]
        public IActionResult GetPlantioUnico(Guid Acesso, int PlantioID)
        {
            var colaborador = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (colaborador == null) return BadRequest("Acesso não encontrado");
            var Plantio = _context.Plantio.SingleOrDefault(o => o.ID == PlantioID);
            if (Plantio == null) return BadRequest("Plantio não encontrado");
            if (Plantio.EmpresaID != colaborador.Usuario.EmpresaID) return BadRequest("Usuario não é da mesma empresa do plantio");

            return Ok(Plantio);
        }
        [HttpGet]
        public IActionResult GetPlantioLista(Guid Acesso)
        {
            var colaborador = _context.Colaboradores.SingleOrDefault(o => o.Usuario.Acesso == Acesso);
            if (colaborador == null) return BadRequest("Acesso não encontrado");
            List<PlantioEntidade> ListaPlantio = _context.Plantio.Where(o=> o.EmpresaID == colaborador.Usuario.EmpresaID).ToList();

            return Ok(ListaPlantio); 
        }
    }
}
