using Cinema.Models;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class OficiosDePessoasRepository : IOficiosDePessoas
    {
        private readonly CinemaContext _context;

        public OficiosDePessoasRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task Create(OficiosDePessoas oficioDePessoas)
        {
            await _context.OficiosDePessoas.AddAsync(oficioDePessoas);
            await _context.SaveChangesAsync();
        }

        public Task Delete(OficiosDePessoas oficioDePessoas)
        {
            _context.OficiosDePessoas.Remove(oficioDePessoas);
            return _context.SaveChangesAsync();
        }

        public Task<OficiosDePessoas?> GetById(int oficioId, int pessoaId)
        {
            var oficioDePessoas = _context.OficiosDePessoas
                .Where(op => op.OficioId == oficioId && op.PessoaId == pessoaId)
                .FirstOrDefaultAsync();
            return oficioDePessoas!;
        }

        public Task<List<OficiosDePessoas>> GetAll()
        {
            var oficiosDePessoas = _context.OficiosDePessoas
                .ToListAsync();
            return oficiosDePessoas;
        }

        public Task<List<OficiosDePessoas>> GetByOficioId(int oficioId)
        {
            var oficiosDePessoas = _context.OficiosDePessoas
                .Where(op => op.OficioId == oficioId)
                .ToListAsync();
            return oficiosDePessoas;
        }

        public Task<List<OficiosDePessoas>> GetByOficioName(string oficioName)
        {
            var oficiosDePessoas = _context.OficiosDePessoas
                .Include(op => op.Oficio)
                .Where(op => op.Oficio!.Nome!.Contains(oficioName))
                .ToListAsync();
            return oficiosDePessoas;
        }

        public Task<List<OficiosDePessoas>> GetByPessoaId(int pessoaId)
        {
            var oficiosDePessoas = _context.OficiosDePessoas
                .Where(op => op.PessoaId == pessoaId)
                .ToListAsync();
            return oficiosDePessoas;
        }

        public Task<List<OficiosDePessoas>> GetByPessoaName(string pessoaName)
        {
            var oficiosDePessoas = _context.OficiosDePessoas
                .Include(op => op.Pessoa)
                .Where(op => op.Pessoa!.PrimeiroNome!.Contains(pessoaName))
                .ToListAsync();
            return oficiosDePessoas;
        }

        public Task Update(OficiosDePessoas oficioDePessoas)
        {
            _context.OficiosDePessoas.Update(oficioDePessoas);
            return _context.SaveChangesAsync();
        }
    }
}
