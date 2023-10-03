using DDD.Domain.EventosContext;
using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        readonly IEventoRepository _eventosRepository;

        public EventoController(IEventoRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        // GET: api/<EventoController>
        [HttpGet]
        public ActionResult<List<Eventos>> Get()
        {
            return Ok(_eventosRepository.GetEventos());
        }

        [HttpGet("{id}")]
        public ActionResult<Eventos> GetById(int id)
        {
            return Ok(_eventosRepository.GetEventosById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Eventos> CreateEventos(Eventos eventos)
        {
            if (eventos.NomeEvento.Length < 3 || eventos.NomeEvento.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _eventosRepository.InsertEventos(eventos);
            return CreatedAtAction(nameof(GetById), new { id = eventos.IdEvento }, eventos);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Eventos eventos)
        {
            try
            {
                if (eventos == null)
                    return NotFound();

                _eventosRepository.UpdateEventos(eventos);
                return Ok("Evento Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Eventos eventos)
        {
            try
            {
                if (eventos == null)
                    return NotFound();

                _eventosRepository.DeleteEventos(eventos);
                return Ok("Evento Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
