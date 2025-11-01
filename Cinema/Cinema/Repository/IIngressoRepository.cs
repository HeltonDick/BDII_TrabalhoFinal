using Cinema.Models;

namespace Cinema.Repository
{
    public interface IIngressoRepository
    {
        public Task Create(Ingresso ingresso);
        public Task Update(Ingresso ingresso);
        public Task Delete(Ingresso ingresso);
        public Task<Ingresso?> GetById(int id);
        public Task<List<Ingresso>> GetAll();
    }
}
