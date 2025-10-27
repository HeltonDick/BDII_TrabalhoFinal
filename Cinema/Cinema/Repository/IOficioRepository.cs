using Cinema.Models;

namespace Cinema.Repository
{
    public interface IOficioRepository
    {
        public Task Create(Oficio oficio);
        public Task Update(Oficio oficio);
        public Task Delete(Oficio oficio);
        public Task<Oficio?> Get(int oficioId);
        public Task<List<Oficio>> GetAll();
        public Task<List<Oficio>> GetByName(string name);
    }
}
