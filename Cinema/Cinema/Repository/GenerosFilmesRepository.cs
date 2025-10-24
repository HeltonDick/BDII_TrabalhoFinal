using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class GenerosFilmesRepository : IGenerosFilmesRepository
    {
        private readonly CinemaContext _context;
        public GenerosFilmesRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(GenerosFilmes generosFilmes)
        {
            await _context.GenerosFilmes.AddAsync(generosFilmes);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(GenerosFilmes generosFilmes)
        {
            _context.GenerosFilmes.Remove(generosFilmes);
            await _context.SaveChangesAsync();
        }

        public async Task<GenerosFilmes>? Get(int generoId, int filmeId)
        {
            var generosFilmes = await _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .Where(gf => gf.GeneroId == generoId && gf.FilmeId == filmeId)
                .FirstOrDefaultAsync();

            return generosFilmes;
        }

        public async Task<List<GenerosFilmes>> GetAll()
        {
            var generosFilmes = await _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .ToListAsync();
            return generosFilmes;
        }

        public async Task<List<GenerosFilmes>?> GetByFilmeId(int filmeId)
        {
            var generosFilmes = await _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .Where(gf => gf.FilmeId == filmeId)
                .ToListAsync();
            return generosFilmes;
        }

        public async Task<List<GenerosFilmes>> GetByFilmeName(string filmeName)
        {
            var generosFilmes = await _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .Where(gf => gf.Filme!.Titulo!
                    .ToLower()
                    .Contains(filmeName.ToLower())
                )
                .ToListAsync();
            return generosFilmes;
        }

        public async Task<List<GenerosFilmes>?> GetByGeneroId(int generoId)
        {
            var generosFilmes = await _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .Where(gf => gf.GeneroId == generoId)
                .ToListAsync();
            return generosFilmes;
        }

        public Task<List<GenerosFilmes>> GetByGeneroName(string generoName)
        {
            var generosFilmes = _context.GenerosFilmes
                .Include(gf => gf.Genero)
                .Include(gf => gf.Filme)
                .Where(gf => gf.Genero!.Name!
                    .ToLower()
                    .Contains(generoName.ToLower())
                )
                .ToListAsync();
            return generosFilmes;
        }

        public Task Update(GenerosFilmes generosFilmes)
        {
            _context.GenerosFilmes.Update(generosFilmes);
            return _context.SaveChangesAsync();
        }
    }
}
