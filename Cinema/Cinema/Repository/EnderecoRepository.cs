using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CinemaContext _context;
        public EnderecoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            return _context.SaveChangesAsync();
        }

        public Task<List<Endereco>> GetAll()
        {
            return _context.Enderecos.ToListAsync();
        }

        public Task<List<Endereco>> GetByCep(string cep)
        {
            return _context.Enderecos.Where(e => e.Cep == cep).ToListAsync();
        }

        public Task<Endereco?> GetById(int id)
        {
            return _context.Enderecos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
