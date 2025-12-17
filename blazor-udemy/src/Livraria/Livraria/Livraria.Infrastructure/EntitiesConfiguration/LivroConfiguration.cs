using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infrastructure.EntitiesConfiguration;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(t => t.LivroId);
        builder.Property(t => t.Titulo).IsRequired()
            .HasMaxLength(150);
        builder.Property(t => t.Autor).IsRequired()
            .HasMaxLength(200);
        builder.Property(t => t.Lancamento).IsRequired();
        builder.Property(t => t.Capa).IsRequired()
            .HasMaxLength(200);
    }
}