using Microsoft.AspNetCore.Mvc;
using ProEventosVS.API.Data;
using ProEventosVS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventosVS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
{
        private readonly DataContext _context;      

        ///Teste
        public EventosController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }
    }
}
