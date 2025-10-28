using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class SalasPadraoRepository : ISalasPadraoRepository
    {
        private readonly CinemaContext _context;
        public SalasPadraoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(SalasPadrao salasPadrao)
        {
            await _context.SalasPadrao.AddAsync(salasPadrao);
            await _context.SaveChangesAsync();
        }

        public Task Delete(SalasPadrao salasPadrao)
        {
            _context.SalasPadrao.Remove(salasPadrao);
            return _context.SaveChangesAsync();
        }

        public Task<List<SalasPadrao>> GetAll()
        {
            return _context.SalasPadrao.ToListAsync();
        }

        public Task<SalasPadrao?> GetById(int id)
        {
            return _context.SalasPadrao.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task Update(SalasPadrao salasPadrao)
        {
            _context.SalasPadrao.Update(salasPadrao);
            return _context.SaveChangesAsync();
        }
    }
}
