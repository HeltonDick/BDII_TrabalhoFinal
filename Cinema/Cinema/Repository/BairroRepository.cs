using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class BairroRepository : IBairroRepository
    {
        private readonly CinemaContext _context;
        public BairroRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Bairro bairro)
        {
            await _context.Bairros.AddAsync(bairro);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Bairro bairro)
        {
            _context.Bairros.Remove(bairro);
            return _context.SaveChangesAsync();
        }

        public Task<List<Bairro>> GetAll()
        {
            var bairros = _context.Bairros.ToListAsync();
            return bairros;
        }

        public Task<Bairro?> GetById(int id)
        {
            var bairros = _context.Bairros.FirstOrDefaultAsync(i => i.Id == id);
            return bairros;
        }

        public Task<List<Bairro>> GetByName(string name)
        {
            var bairros = _context.Bairros
                .Where(i => i.Nome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();

            return bairros;
        }

        public Task Update(Bairro bairro)
        {
            _context.Bairros.Update(bairro);
            return _context.SaveChangesAsync();
        }
    }
}
