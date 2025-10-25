using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class EstudioFilmesRepository : IEstudioFilmesRepository
    {
        private readonly CinemaContext _context;
        public EstudioFilmesRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(EstudiosFilmes estudiosFilmes)
        {
            await _context.EstudiosFilmes.AddAsync(estudiosFilmes);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(EstudiosFilmes estudiosFilmes)
        {
            _context.EstudiosFilmes.Remove(estudiosFilmes);
            await _context.SaveChangesAsync();
        }

        public async Task<EstudiosFilmes>? Get(int estudioId, int filmeId)
        {
            var estudioFilmes = await _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .Where(ef => ef.EstudioId == estudioId && ef.FilmeId == filmeId)
                .FirstOrDefaultAsync();

            return estudioFilmes!;
        }

        public async Task<List<EstudiosFilmes>> GetAll()
        {
            var EstudiosFilmes = await _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .ToListAsync();
            return EstudiosFilmes;
        }

        public async Task<List<EstudiosFilmes>?> GetByEstudioId(int estudioId)
        {
            var EstudiosFilmes = await _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .Where(ef => ef.EstudioId == estudioId)
                .ToListAsync();
            return EstudiosFilmes;
        }
        public async Task<List<EstudiosFilmes>> GetByEstudioName(string estudioName)
        {
            var EstudiosFilmes = await _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .Where(ef => ef.Estudio!.Nome!
                    .ToLower()
                    .Contains(estudioName.ToLower())
                )
                .ToListAsync();
            return EstudiosFilmes;
        }

        public Task<List<EstudiosFilmes>?> GetByFilmeId(int filmeId)
        {
            var EstudiosFilmes =  _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .Where(ef => ef.FilmeId == filmeId)
                .ToListAsync();
            return EstudiosFilmes!;
        }

        public Task<List<EstudiosFilmes>> GetByFilmeName(string filmeName)
        {
            var EstudiosFilmes =  _context.EstudiosFilmes
                .Include(ef => ef.Estudio)
                .Include(ef => ef.Filme)
                .Where(ef => ef.Filme!.Titulo!
                    .ToLower()
                    .Contains(filmeName.ToLower())
                )
                .ToListAsync();
            return EstudiosFilmes!;
        }

        public Task Update(EstudiosFilmes estudiosFilmes)
        {
            _context.EstudiosFilmes.Update(estudiosFilmes);
            return _context.SaveChangesAsync();
        }
    }
}
