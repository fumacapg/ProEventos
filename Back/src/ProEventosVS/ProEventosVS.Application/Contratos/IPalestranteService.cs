using ProEventosVS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosVS.Application.Contratos
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrantes(Palestrante model);

        Task<Palestrante> UpdatePalestrantes(int palestranteId, Palestrante model);

        Task<bool> DeletePalestrantes(int palestranteId);

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);

        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}
