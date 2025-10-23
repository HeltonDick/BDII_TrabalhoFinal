using Cinema.Models;

namespace Cinema.Repository
{
    public interface IIdiomaRepository
    {
        public Task Create(Idioma idioma);
        public Task Update(Idioma idioma);
        public Task Delete(Idioma idioma);

        public Task<Idioma?> GetById(int id);
        public Task<List<Idioma>> GetAll();
        public Task<List<Idioma>> GetByName(string name);
    }
}
