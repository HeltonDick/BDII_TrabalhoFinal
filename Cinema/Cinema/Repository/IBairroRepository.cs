using Cinema.Models;

namespace Cinema.Repository
{
    public interface IBairroRepository
    {
        public Task Create(Bairro bairro);
        public Task Update(Bairro bairro);
        public Task Delete(Bairro bairro);

        public Task<Bairro?> GetById(int id);
        public Task<List<Bairro>> GetAll();
        public Task<List<Bairro>> GetByName(string name);
    }
}
