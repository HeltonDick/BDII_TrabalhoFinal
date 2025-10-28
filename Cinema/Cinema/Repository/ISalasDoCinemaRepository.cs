using Cinema.Models;

namespace Cinema.Repository
{
    public interface ISalasDoCinemaRepository
    {
        public Task Create(SalasDoCinema salasDoCinema);
        public Task Update(SalasDoCinema salasDoCinema);
        public Task Delete(SalasDoCinema salasDoCinema);
        public Task<SalasDoCinema?> GetById(int id);
        public Task<List<SalasDoCinema>> GetAll();
    }
}
