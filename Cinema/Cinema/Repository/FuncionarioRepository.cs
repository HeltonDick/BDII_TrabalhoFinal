using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly CinemaContext _context;
        public FuncionarioRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            return _context.SaveChangesAsync();
        }

        public Task<List<Funcionario>> GetAll()
        {
            return _context.Funcionarios.ToListAsync();
        }

        public Task<Funcionario?> GetById(int id)
        {
            return _context.Funcionarios.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Funcionario>> GetByName(string name)
        {
            return _context.Funcionarios
                .Where(f => f.Pessoa!.PrimeiroNome!
                    .ToLower()
                    .Contains(name.ToLower())
                )
                .ToListAsync();
        }

        public Task Update(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            return _context.SaveChangesAsync();
        }
    }
}
