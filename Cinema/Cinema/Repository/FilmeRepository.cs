using Cinema.Models;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class FilmeRepository : IFilmeRepository
    {

        private readonly CinemaContext _context;
        public FilmeRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Filme filme)
        {
            await _context.Filmes.AddAsync(filme);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Filme filme)
        {
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public Task<Filme?> Get(int id)
        {
            var filme = _context.Filmes
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
            return filme;
        }

        public Task<List<Filme>> GetAll()
        {
            var filmes = _context.Filmes
                .ToListAsync();
            return filmes;
        }

        public Task<List<Filme>> GetByName(string name)
        {
            var filmes = _context.Filmes
                .Where(f => f.Titulo!.Contains(name))
                .ToListAsync();
            return filmes!;
        }

        public async Task Update(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }
    }
}
