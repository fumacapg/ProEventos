using Microsoft.AspNetCore.Mvc;
using ProEventosVS.Persistence;
using ProEventosVS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using ProEventosVS.Application.Contratos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProEventosVS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null)
                    return NotFound("Nenhum evento encontrado");
                return Ok(eventos);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os eventos. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento == null)
                    return NotFound($"Nenhum evento encontrado com o id: {id}");
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o evento pelo id: {id}. Erro: {e.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<ActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null)
                    return NotFound($"Nenhum evento encontrado com o tema: {tema}");
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o evento pelo tema: {tema}. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento == null)
                    return BadRequest("Erro ao adicionar evento");
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar um evento. Erro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventos(id, model);
                if (evento == null)
                    return BadRequest($"Erro ao alterar o evento id: {id}");
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar alterar um evento. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoService.DeleteEventos(id))
                    return Ok("Excluído com sucesso");
                return BadRequest($"Erro ao excluir o evento id: {id}");

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir um evento. Erro: {e.Message}");
            }
        }
    }
}
