using Cinema.Models;

namespace Cinema.Repository
{
    public interface IPessoaRepository
    {
        public Task Create(Pessoa pessoa);
        public Task Update(Pessoa pessoa);
        public Task Delete(Pessoa pessoa);

        public Task<Pessoa?> GetById(int id);
        public Task<List<Pessoa>> GetAll();
        public Task<List<Pessoa>> GetByName(string name);
    }
}
