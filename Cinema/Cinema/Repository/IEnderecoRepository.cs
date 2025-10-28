using Cinema.Models;

namespace Cinema.Repository
{
    public interface IEnderecoRepository
    {
        public Task Create(Endereco endereco);
        public Task Update(Endereco endereco);
        public Task Delete(Endereco endereco);
        public Task<Endereco?> GetById(int id);
        public Task<List<Endereco>> GetAll();
        public Task<List<Endereco>> GetByCep(string cep);
    }
}
