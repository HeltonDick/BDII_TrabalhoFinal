using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly CinemaContext _context;
        public SessaoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Sessao sessao)
        {
            await _context.Sessoes.AddAsync(sessao);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Sessao sessao)
        {
            _context.Sessoes.Remove(sessao);
            return _context.SaveChangesAsync();
        }

        public Task<List<Sessao>> GetAll()
        {
            return _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Idioma)
                .Include(s => s.Dimenssao)
                .Include(s => s.salasDoCinema)
                .ToListAsync();
        }

        public Task<Sessao?> GetById(int id)
        {
            return _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Idioma)
                .Include(s => s.Dimenssao)
                .Include(s => s.salasDoCinema)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task Update(Sessao sessao)
        {
            _context.Sessoes.Update(sessao);
            return _context.SaveChangesAsync();
        }
    }
}
