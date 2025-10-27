using Cinema.Models;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class OficioRepository : IOficioRepository
    {
        private CinemaContext _context;

        public OficioRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(Oficio oficio)
        {
            await _context.Oficios.AddAsync(oficio);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Oficio oficio)
        {
            _context.Oficios.Remove(oficio);
            return _context.SaveChangesAsync();
        }

        public Task<Oficio?> Get(int oficioId)
        {
            var oficio = _context.Oficios
                .Where(o => o.Id == oficioId)
                .FirstOrDefaultAsync();
            return oficio!;
        }

        public Task<List<Oficio>> GetAll()
        {
            var oficios = _context.Oficios
                .ToListAsync();
            return oficios;
        }

        public Task<List<Oficio>> GetByName(string name)
        {
            var oficios = _context.Oficios
                .Where(o => o.Nome!.Contains(name))
                .ToListAsync();
            return oficios!;
        }

        public async Task Update(Oficio oficio)
        {
            _context.Oficios.Update(oficio);
            await _context.SaveChangesAsync();
        }
    }
}
