using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class ClassificaoRepository : IClassificacaoRepository
    {
        private readonly CinemaContext _context;
        public ClassificaoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Classificacao classificacao)
        {
            await _context.Classificacoes.AddAsync(classificacao);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Classificacao classificacao)
        {
            _context.Classificacoes.Remove(classificacao);
            await _context.SaveChangesAsync();
        }

        public Task<List<Classificacao>> GetAll()
        {
            var classificacoes = _context.Classificacoes.ToListAsync();
            return classificacoes;
        }

        public Task<Classificacao?> GetById(int id)
        {
            var classificacoes = _context.Classificacoes.FirstOrDefaultAsync(i => i.Id == id);
            return classificacoes;
        }

        public Task<List<Classificacao>> GetByName(string name)
        {
            var classificacoes = _context.Classificacoes
                .Where(i => i.Nome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();
            return classificacoes;
        }

        public Task Update(Classificacao classificacao)
        {
            _context.Classificacoes.Update(classificacao);
            return _context.SaveChangesAsync();
        }
    }
}
