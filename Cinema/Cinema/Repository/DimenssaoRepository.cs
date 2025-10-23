using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class DimenssaoRepository : IDimensaoRepository
    {
        private readonly CinemaContext _context;
        public DimenssaoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Dimenssao dimenssao)
        {
            await _context.Dimenssoes.AddAsync(dimenssao);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Dimenssao dimenssao)
        {
            _context.Dimenssoes.Remove(dimenssao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dimenssao>> GetAll()
        {
            var Dimenssoes = await _context.Dimenssoes.ToListAsync();
            return Dimenssoes;
        }

        public Task<Dimenssao?> GetById(int id)
        {
            var dimenssao = _context.Dimenssoes.FirstOrDefaultAsync(i => i.Id == id);
            return dimenssao;
        }

        public Task<List<Dimenssao>> GetByName(string name)
        {
            var dimenssao = _context.Dimenssoes
                .Where(i => i.Name!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();
            return dimenssao;
        }

        public Task Update(Dimenssao dimensao)
        {
            _context.Dimenssoes.Update(dimensao);
            return _context.SaveChangesAsync();
        }
    }
}
