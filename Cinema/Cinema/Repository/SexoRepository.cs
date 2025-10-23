using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class SexoRepository : ISexoRepository
    {
        private readonly CinemaContext _context;

        public SexoRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(Sexo sexo)
        {
            await _context.Sexos.AddAsync(sexo);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Sexo sexo)
        {
            _context.Sexos.Remove(sexo);
            return _context.SaveChangesAsync();
        }

        public async Task<List<Sexo>> GetAll()
        {
            var sexos = await _context.Sexos.ToListAsync();
            return sexos;
        }

        public async Task<Sexo?> GetById(int id)
        {
            var sexo = await _context.Sexos.FirstOrDefaultAsync(s => s.Id == id);
            return sexo;
        }

        public async Task<List<Sexo>> GetByName(string name)
        {
            var sexos = await _context.Sexos
                .Where(s => s.Nome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();

            return sexos;
        }

        public Task Update(Sexo sexo)
        {
            _context.Sexos.Update(sexo);
            return _context.SaveChangesAsync();
        }
    }
}
