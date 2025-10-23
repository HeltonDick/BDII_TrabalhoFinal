using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private readonly CinemaContext _context;
        public IdiomaRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Idioma idioma)
        {
            await _context.Idiomas.AddAsync(idioma);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Idioma idioma)
        {
            _context.Idiomas.Remove(idioma);
            await _context.SaveChangesAsync();
        }

        public Task<List<Idioma>> GetAll()
        {
            var idiomas = _context.Idiomas.ToListAsync();
            return idiomas;
        }

        public Task<Idioma?> GetById(int id)
        {
            var idiomas = _context.Idiomas.FirstOrDefaultAsync(i => i.Id == id);
            return idiomas;
        }

        public Task<List<Idioma>> GetByName(string name)
        {
            var idiomas = _context.Idiomas
                .Where(i => i.Name!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();

            return idiomas;
        }

        public Task Update(Idioma idioma)
        {
            _context.Idiomas.Update(idioma);
            return _context.SaveChangesAsync();
        }
    }
}
