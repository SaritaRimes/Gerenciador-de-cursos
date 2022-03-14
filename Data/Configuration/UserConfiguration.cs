using GerenciadorDeCursos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Username).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Role).HasConversion<string>().IsRequired();
        }
    }
}