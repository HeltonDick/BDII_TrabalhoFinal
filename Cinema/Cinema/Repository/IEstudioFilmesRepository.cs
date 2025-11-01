using Cinema.Models;

namespace Cinema.Repository
{
    public interface IEstudioFilmesRepository
    {
        public Task Create(EstudiosFilmes estudiosFilmes);
        public Task Update(EstudiosFilmes estudiosFilmes);
        public Task Delete(EstudiosFilmes estudiosFilmes);

        public Task<List<EstudiosFilmes>?> GetByFilmeId(int filmeId);
        public Task<List<EstudiosFilmes>?> GetByEstudioId(int estudioId);

        public Task<EstudiosFilmes>? GetById(int estudioId, int filmeId);
        public Task<List<EstudiosFilmes>> GetAll();

        public Task<List<EstudiosFilmes>> GetByFilmeName(string filmeName);
        public Task<List<EstudiosFilmes>> GetByEstudioName(string estudioName);
    }
}
