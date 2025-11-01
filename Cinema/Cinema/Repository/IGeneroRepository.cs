using Cinema.Models;

namespace Cinema.Repository
{
    public interface IGeneroRepository
    {
        public Task Create(Genero genero);
        public Task Update(Genero genero);
        public Task Delete(Genero genero);

        public Task<Genero>? GetById(int generoId);
        public Task<List<Genero>> GetAll();
        public Task<List<Genero>> GetByName(string name);
    }
}
