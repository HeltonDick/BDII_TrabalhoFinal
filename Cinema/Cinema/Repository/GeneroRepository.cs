using Cinema.Models;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private CinemaContext _context;
        public GeneroRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(Genero genero)
        {
            await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Genero genero)
        {
            _context.Generos.Remove(genero);
            return _context.SaveChangesAsync();
        }

        public Task<Genero>? Get(int generoId)
        {
            var genero = _context.Generos
                .Where(g => g.Id == generoId)
                .FirstOrDefaultAsync();
            return genero!;
        }

        public Task<List<Genero>> GetAll()
        {
            var generos = _context.Generos
                .ToListAsync();
            return generos;
        }

        public Task<List<Genero>> GetByName(string name)
        {
            var generos = _context.Generos
                .Where(g => g.Name!.Contains(name))
                .ToListAsync();
            return generos!;
        }

        public async Task Update(Genero genero)
        {
            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();
        }
    }
}
