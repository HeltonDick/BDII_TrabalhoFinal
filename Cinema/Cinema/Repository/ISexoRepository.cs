using Cinema.Models;

namespace Cinema.Repository
{
    public interface ISexoRepository
    {
        public Task Create(Sexo sexo);
        public Task Update(Sexo sexo);
        public Task Delete(Sexo sexo);

        public Task<Sexo?> GetById(int id);
        public Task<List<Sexo>> GetAll();
        public Task<List<Sexo>> GetByName(string name);
    }
}
