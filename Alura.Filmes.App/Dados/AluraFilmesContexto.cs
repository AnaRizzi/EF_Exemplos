using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AluraFilmesTST;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* ATORES */
            modelBuilder.ApplyConfiguration(new AtorConfig());

            /* FILMES */
            modelBuilder.ApplyConfiguration(new FilmeConfig());

            /* FILMES E ATORES */
            modelBuilder.ApplyConfiguration(new FilmeAtorConfig());

            /* CATEGORIAS */
            modelBuilder.ApplyConfiguration(new CategoriaConfig());

            /* FILMES E CATEGORIAS */
            modelBuilder.ApplyConfiguration(new FilmeCategoriaConfig());

            /* IDIOMAS */
            modelBuilder.ApplyConfiguration(new IdiomaConfig());
        }
    }
}
