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

            builder
                .Property(f => f.TextoClassificacao)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");

            //para o entity ignorar essa propriedade
            builder
                .Ignore(f => f.Classificacao);

            //Shadow Property - tem na tabela, mas não tem na regra de negócio
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder
                .Property<byte>("language_id")
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property<byte?>("original_language_id")
                .HasColumnType("tinyint");

            builder
                .HasOne(f => f.IdiomaFalado)
                .WithMany(i => i.FilmesFalados)
                .HasForeignKey("language_id");

            builder
                .HasOne(f => f.IdiomaOriginal)
                .WithMany(i => i.FilmesOriginais)
                .HasForeignKey("original_language_id");
        }
    }
}
