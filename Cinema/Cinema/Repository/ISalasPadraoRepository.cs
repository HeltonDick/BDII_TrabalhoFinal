using Cinema.Models;

namespace Cinema.Repository
{
    public interface ISalasPadraoRepository
    {
        public Task Create(SalasPadrao salasPadrao);
        public Task Update(SalasPadrao salasPadrao);
        public Task Delete(SalasPadrao salasPadrao);
        public Task<SalasPadrao?> GetById(int id);
        public Task<List<SalasPadrao>> GetAll();
    }
}
