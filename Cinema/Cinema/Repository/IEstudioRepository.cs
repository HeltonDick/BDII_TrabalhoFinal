using Cinema.Models;

namespace Cinema.Repository
{
    public interface IEstudioRepository
    {
        public Task Create(Estudio estudio);
        public Task Update(Estudio estudio);
        public Task Delete(Estudio estudio);
        public Task<Estudio>? Get(int id);
        public Task<List<Estudio>> GetAll();
        public Task<List<Estudio>> GetByName(string name);
    }
}
