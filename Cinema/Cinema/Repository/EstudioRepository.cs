using Cinema.Models;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{

    public class EstudioRepository : IEstudioRepository
    {
        private readonly CinemaContext _context;
        public EstudioRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(Estudio estudio)
        {
            await _context.Estudios.AddAsync(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Estudio estudio)
        {
            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
        }

        public Task<Estudio>? Get(int id)
        {
            var estudio = _context.Estudios
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            return estudio!;
        }

        public Task<List<Estudio>> GetAll()
        {
            var estudios = _context.Estudios
                .ToListAsync();
            return estudios;
        }

        public Task<List<Estudio>> GetByName(string name)
        {
            var estudios = _context.Estudios
                .Where(e => e.Nome!.Contains(name))
                .ToListAsync();
            return estudios!;
        }

        public async Task Update(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
            await  _context.SaveChangesAsync();
        }
    }
}
