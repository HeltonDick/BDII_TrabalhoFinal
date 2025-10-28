using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class SalasDoCinemaRepository : ISalasDoCinemaRepository
    {
        private readonly CinemaContext _context;
        public SalasDoCinemaRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(SalasDoCinema salasDoCinema)
        {
            await _context.SalasDoCinema.AddAsync(salasDoCinema);
            await _context.SaveChangesAsync();
        }

        public Task Delete(SalasDoCinema salasDoCinema)
        {
            _context.SalasDoCinema.Remove(salasDoCinema);
            return _context.SaveChangesAsync();
        }

        public Task<List<SalasDoCinema>> GetAll()
        {
            return _context.SalasDoCinema
                .Include(s => s.SalasPadrao)
                .Include(s => s.Assento)
                .ToListAsync();
        }

        public Task<SalasDoCinema?> GetById(int id)
        {
            return _context.SalasDoCinema
                .Include(s => s.SalasPadrao)
                .Include(s => s.Assento)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task Update(SalasDoCinema salasDoCinema)
        {
            _context.SalasDoCinema.Update(salasDoCinema);
            return _context.SaveChangesAsync();
        }
    }
}
