using GerenciadorDeCursos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Data.Configuration
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        // Cria o modelo de dados para a entidade Curso
        public void Configure (EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos"); //nome da tabela
            builder.HasKey(p => p.Id); //chave primaria
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DuracaoEmHoras).HasMaxLength(4).IsRequired();
            builder.Property(p => p.Status).HasConversion<string>();
        }
    }
}