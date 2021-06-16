using Microsoft.EntityFrameworkCore;
using ProEventosVS.Domain;
using ProEventosVS.Persistence.Contextos;
using ProEventosVS.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosVS.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosVSContext _context;

        public EventoPersistence(ProEventosVSContext context)
        {
            _context = context;
        }
        
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking().Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking().Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking().Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }        
    }
}
