
using Cinema.Models;

namespace Cinema.Repository
{
    public interface IFilmeRepository
    {
        public Task Create(Filme filme);
        public Task Update(Filme filme);
        public Task Delete(Filme filme);
        public Task<Filme?> GetById(int id);
        public Task<List<Filme>> GetAll();
        public Task<List<Filme>> GetByName(string name);
    }
}
