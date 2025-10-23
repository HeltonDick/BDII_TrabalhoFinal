using Cinema.Models;

namespace Cinema.Repository
{
    public interface ITipoDeSalaRepository
    {
        public Task Create(TipoDeSala tipoDeSala);
        public Task Update(TipoDeSala tipoDeSala);
        public Task Delete(TipoDeSala tipoDeSala);
        public Task<TipoDeSala?> GetById(int id);
        public Task<List<TipoDeSala>> GetAll();
        public Task<List<TipoDeSala>> GetByName(string name);
    }
}
