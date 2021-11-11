using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfig : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            /* FILMES */
            builder
                .ToTable("film");

            builder
                .Property(f => f.Id)
                .HasColumnName("film_id");

            builder
                .Property(f => f.Titulo)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(f => f.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(f => f.Duracao)
                .HasColumnName("length")
                .HasColumnType("smallint");

            //Shadow Property - tem na tabela, mas não tem na regra de negócio
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");
        }
    }
}
