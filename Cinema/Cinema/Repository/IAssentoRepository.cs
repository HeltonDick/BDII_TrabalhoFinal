using Cinema.Models;

namespace Cinema.Repository
{
    public interface IAssentoRepository
    {
        public Task Create(Assento assento);
        public Task Delete(Assento assento);
        public Task<Assento?> GetById(int id);
        public Task<List<Assento>> GetAll();
    }
}
