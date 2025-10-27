using Cinema.Models;

namespace Cinema.Repository
{
    public interface ICinemasRepository
    {
        public Task Cretae(Cinemas cinema);
        public Task Update(Cinemas cinema);
        public Task Delete(Cinemas cinema);
        public Task<Cinemas?> GetById(int id);
        public Task<List<Cinemas>> GetAll();
        public Task<List<Cinemas>> GetByName(string name);
    }
}
