using ProEventosVS.Application.Contratos;
using ProEventosVS.Domain;
using ProEventosVS.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosVS.Application
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IPalestrantePersistence _palestrantePersistence;
        public PalestranteService(IGeralPersistence geralPersistence, IPalestrantePersistence palestrantePersistence)
        {
            _geralPersistence = geralPersistence;
            _palestrantePersistence = palestrantePersistence;
        }

        public async Task<Palestrante> AddPalestrantes(Palestrante model)
        {
            try
            {
                _geralPersistence.Add(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _palestrantePersistence.GetPalestranteByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrantes(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _palestrantePersistence.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null)
                    return null;

                model.Id = palestrante.Id;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _palestrantePersistence.GetPalestranteByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeletePalestrantes(int palestranteId)
        {
            try
            {
                var palestrante = await _palestrantePersistence.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null)
                    throw new Exception("O Palestrante não foi localizado para exclusão");

                _geralPersistence.Delete<Palestrante>(palestrante);
                return await _geralPersistence.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersistence.GetAllPalestrantesAsync(includeEventos);
                if (palestrantes == null) return null;
                return palestrantes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersistence.GetAllPalestrantesByNomeAsync(nome, includeEventos);
                if (palestrantes == null) return null;
                return palestrantes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersistence.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if (palestrantes == null) return null;
                return palestrantes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
    }
}
