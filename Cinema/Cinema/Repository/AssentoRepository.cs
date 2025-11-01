using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class AssentoRepository : IAssentoRepository
    {
        private readonly CinemaContext _context;
        public AssentoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Assento assento)
        {
            await _context.Assentos.AddAsync(assento);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Assento assento)
        {
            _context.Assentos.Remove(assento);
            await _context.SaveChangesAsync();
        }

        public Task<List<Assento>> GetAll()
        {
            return _context.Assentos.ToListAsync();
        }

        public Task<Assento?> GetById(int id)
        {
            return _context.Assentos.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
