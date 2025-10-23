using Cinema.Models;

namespace Cinema.Repository
{
    public interface IDimensaoRepository
    {
        public Task Create(Dimenssao dimensao);
        public Task Update(Dimenssao dimensao);
        public Task Delete(Dimenssao dimensao);
        public Task<Dimenssao?> GetById(int id);
        public Task<List<Dimenssao>> GetAll();
        public Task<List<Dimenssao>> GetByName(string name);
    }
}
