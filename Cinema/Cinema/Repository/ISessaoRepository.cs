using Cinema.Models;

namespace Cinema.Repository
{
    public interface ISessaoRepository
    {
        public Task Create(Sessao sessao);
        public Task Update(Sessao sessao);
        public Task Delete(Sessao sessao);

        public Task<Sessao?> GetById(int id);
        public Task<List<Sessao>> GetAll();
    }
}
