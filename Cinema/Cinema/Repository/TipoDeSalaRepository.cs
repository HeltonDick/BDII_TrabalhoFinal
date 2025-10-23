using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class TipoDeSalaRepository : ITipoDeSalaRepository
    {
        private readonly CinemaContext _context;
        public TipoDeSalaRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(TipoDeSala tipoDeSala)
        {
            await _context.TiposDeSalas.AddAsync(tipoDeSala);
            await _context.SaveChangesAsync();
        }

        public Task Delete(TipoDeSala tipoDeSala)
        {
            _context.TiposDeSalas.Remove(tipoDeSala);
            return _context.SaveChangesAsync();
        }

        public Task<List<TipoDeSala>> GetAll()
        {
            var tiposDeSalas = _context.TiposDeSalas.ToListAsync();
            return tiposDeSalas;
        }

        public Task<TipoDeSala?> GetById(int id)
        {
            var tipoDeSala = _context.TiposDeSalas.FirstOrDefaultAsync(i => i.Id == id);
            return tipoDeSala;
        }

        public Task<List<TipoDeSala>> GetByName(string name)
        {
            var tiposDeSalas = _context.TiposDeSalas
                .Where(i => i.Name!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();
            return tiposDeSalas;
        }

        public Task Update(TipoDeSala tipoDeSala)
        {
            _context.TiposDeSalas.Update(tipoDeSala);
            return _context.SaveChangesAsync();
        }
    }
}
