using Cinema.Data;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class IngressoRepository : IIngressoRepository
    {
        private readonly CinemaContext _context;
        public IngressoRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task Create(Ingresso ingresso)
        {
            await _context.Ingressos.AddAsync(ingresso);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Ingresso ingresso)
        {
            _context.Ingressos.Remove(ingresso);
            return _context.SaveChangesAsync();
        }

        public Task<List<Ingresso>> GetAll()
        {
            return _context.Ingressos
                .ToListAsync();
        }

        public Task<Ingresso?> GetById(int id)
        {
            return _context.Ingressos
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task Update(Ingresso ingresso)
        {
            _context.Ingressos.Update(ingresso);
            return _context.SaveChangesAsync();
        }
    }
}