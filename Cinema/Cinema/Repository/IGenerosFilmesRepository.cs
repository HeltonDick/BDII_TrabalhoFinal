using Cinema.Models;

namespace Cinema.Repository
{
    public interface IGenerosFilmesRepository
    {
        public Task Create(GenerosFilmes generosFilmes);
        public Task Update(GenerosFilmes generosFilmes);
        public Task Delete(GenerosFilmes generosFilmes);

        public Task<List<GenerosFilmes>?> GetByFilmeId(int filmeId);
        public Task<List<GenerosFilmes>?> GetByGeneroId(int generoId);

        public Task<GenerosFilmes>? Get(int generoId, int filmeId);
        public Task<List<GenerosFilmes>> GetAll();

        public Task<List<GenerosFilmes>> GetByFilmeName(string filmeName);
        public Task<List<GenerosFilmes>> GetByGeneroName(string generoName);
    }
}
