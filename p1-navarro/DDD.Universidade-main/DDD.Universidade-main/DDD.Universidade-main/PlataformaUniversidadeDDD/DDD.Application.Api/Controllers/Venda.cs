using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Venda : ControllerBase
    {
        readonly IVendaRepository _vendaRepository;

        public Venda(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        public ActionResult<List<Venda>> Get()
        {
            return Ok(_vendaRepository.GetVendas());
        }

        [HttpGet("{id}")]
        public ActionResult<Eventos> GetById(int id)
        {
            return Ok(_vendaRepository.GetVendaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Venda> CreateVenda(int IdEventos, int UserId)
        {
            var vendaIdSaved = _vendaRepository.InsertVenda(IdEventos, UserId);
            return CreatedAtAction(nameof(GetById), new { id = vendaIdSaved.VendaId }, vendaIdSaved);
        }

    }
}
