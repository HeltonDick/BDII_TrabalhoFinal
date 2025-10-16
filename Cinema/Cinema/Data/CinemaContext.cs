using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using EFTest.Models;

namespace Cinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext (DbContextOptions<CinemaContext> options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<Oficio> Cargos { get; set; }
        public DbSet<Predio> Cinemas { get; set; }
        public DbSet<GenerosFilmes> GenerosFilmes { get; set; }
        public DbSet<Endereco> Enderecos{ get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
