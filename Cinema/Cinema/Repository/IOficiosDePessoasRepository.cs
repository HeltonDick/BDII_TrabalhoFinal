using Cinema.Models;

namespace Cinema.Repository
{
    public interface IOficiosDePessoasRepository
    {
        public Task Create(OficiosDePessoas oficioDePessoas);
        public Task Update(OficiosDePessoas oficioDePessoas);
        public Task Delete(OficiosDePessoas oficioDePessoas);
        public Task<OficiosDePessoas?> GetById(int oficioId, int pessoaId );

        public Task<List<OficiosDePessoas>> GetByPessoaId(int pessoaId);
        public Task<List<OficiosDePessoas>> GetByOficioId(int oficioId);

        public Task<List<OficiosDePessoas>> GetByPessoaName(string pessoaName);
        public Task<List<OficiosDePessoas>> GetByOficioName(string oficioName);

        public Task<List<OficiosDePessoas>> GetAll();
    }
}
