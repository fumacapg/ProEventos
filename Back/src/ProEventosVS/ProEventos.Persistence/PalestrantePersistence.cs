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
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosVSContext _context;

        public PalestrantePersistence(ProEventosVSContext context)
        {
            _context = context;
        }       

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking().Include(p => p.RedesSociais);

            if (includeEventos)
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking().Include(p => p.RedesSociais);

            if (includeEventos)
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }        

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking().Include(p => p.RedesSociais);

            if (includeEventos)
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }        
    }
}
