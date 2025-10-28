using Cinema.Models;

namespace Cinema.Repository
{
    public interface IFuncionarioRepository
    {
        public Task Create(Funcionario funcionario);
        public Task Update(Funcionario funcionario);
        public Task Delete(Funcionario funcionario);

        public Task<List<Funcionario>> GetAll();
        public Task<Funcionario?> GetById(int id);
        public Task<List<Funcionario>> GetByName(string name);
    }
}
