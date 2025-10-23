using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly CinemaContext _context;

        public PessoaRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> GetAll()
        {
            var pessoas = await _context.Pessoas.ToListAsync();
            return pessoas;
        }

        public Task<Pessoa?> GetById(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            return pessoa;
        }

        public async Task<List<Pessoa>> GetByName(string name)
        {
            var pessoas = await _context.Pessoas
                .Where(p => p.PrimeiroNome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();

            return pessoas;
        }

        public async Task Update(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
