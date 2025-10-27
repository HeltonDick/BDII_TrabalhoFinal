using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class CinemaRepository : ICinemasRepository
    {
        private readonly CinemaContext _context;
        public CinemaRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Cretae(Cinemas cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Cinemas cinema)
        {
            _context.Cinemas.Remove(cinema);
            return _context.SaveChangesAsync();
        }

        public async Task<List<Cinemas>> GetAll()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return cinemas;
        }

        public async Task<Cinemas?> GetById(int id)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(i => i.Id == id);
            return cinema;
        }

        public Task<List<Cinemas>> GetByName(string name)
        {
            var cinema = _context.Cinemas
                .Where(c => c.Nome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();
            return cinema;
        }

        public Task Update(Cinemas cinema)
        {
            _context.Cinemas.Update(cinema);
            return _context.SaveChangesAsync();
        }
    }
}
