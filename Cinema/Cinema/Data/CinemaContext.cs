using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext (DbContextOptions<CinemaContext> options) : base(options)
        {
        }
        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Dimenssao> Dimenssoes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<Oficio> Oficios { get; set; }
        public DbSet<OficiosDePessoas> OficiosDePessoas { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<GenerosFilmes> GenerosFilmes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<EstudiosFilmes> EstudiosFilmes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<SalasDoCinema> SalasDoCinema { get; set; }
        public DbSet<SalasPadrao> SalasPadroes { get; set; }
        public DbSet<TipoDeSala> TiposDeSalas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assento>().ToTable("Assento");
            modelBuilder.Entity<Idioma>().ToTable("Idioma");
            modelBuilder.Entity<Bairro>().ToTable("Bairro");
            modelBuilder.Entity<Dimenssao>().ToTable("Dimenssao");
            modelBuilder.Entity<Filme>().ToTable("Filme");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<Classificacao>().ToTable("Classificacao");
            modelBuilder.Entity<Oficio>().ToTable("Oficio");
            modelBuilder.Entity<OficiosDePessoas>().ToTable("OficioDePessoa");
            modelBuilder.Entity<Cinemas>().ToTable("Cinema");
            modelBuilder.Entity<Filme>().ToTable("GeneroFilme");
            modelBuilder.Entity<Genero>().ToTable("Endereco");
            modelBuilder.Entity<Filme>().ToTable("Estudio");
            modelBuilder.Entity<Genero>().ToTable("EstudioFilme");
            modelBuilder.Entity<Genero>().ToTable("Funcionario");
            modelBuilder.Entity<Genero>().ToTable("Pessoa");
            modelBuilder.Entity<Genero>().ToTable("Sexo");
            modelBuilder.Entity<Filme>().ToTable("SalaDoCinema");
            modelBuilder.Entity<Genero>().ToTable("SalaPadrao");
            modelBuilder.Entity<Filme>().ToTable("TipoDeSalas");
        }
    }
}
