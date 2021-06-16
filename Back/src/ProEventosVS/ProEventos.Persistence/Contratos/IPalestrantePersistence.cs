using ProEventosVS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosVS.Persistence.Contratos
{
    public interface IPalestrantePersistence
    {
        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}
