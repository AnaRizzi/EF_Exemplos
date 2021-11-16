using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AtorConfig : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder
                .ToTable("actor");

            builder
                .Property(a => a.Id)
                .HasColumnName("actor_id");

            builder
                .Property(a => a.PrimeiroNome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(a => a.UltimoNome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            //Shadow Property - tem na tabela, mas não tem na regra de negócio
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            //inserindo índice para uma propriedade que não é FK
            //se não passar o nome, ele irá criar com o nome IX_tabela_campo
            builder
                .HasIndex(a => a.UltimoNome)
                .HasName("idx_actor_last_name");

            //criando chave alternativa para incluir o Unique com dois campos
            builder
                .HasAlternateKey(a => new { a.PrimeiroNome, a.UltimoNome });
        }
    }
}
