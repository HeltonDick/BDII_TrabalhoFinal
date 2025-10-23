using Cinema.Models;

namespace Cinema.Repository
{
    public interface IClassificacaoRepository
    {
        public Task Create(Classificacao classificacao);
        public Task Update(Classificacao classificacao);
        public Task Delete(Classificacao classificacao);

        public Task<Classificacao?> GetById(int id);
        public Task<List<Classificacao>> GetAll();
        public Task<List<Classificacao>> GetByName(string name);
    }
}
