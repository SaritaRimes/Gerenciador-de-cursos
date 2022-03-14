using GerenciadorDeCursos.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCursos.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = GerenciadorDeCursos; User Id = sa; Password = SenhaAqui");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}