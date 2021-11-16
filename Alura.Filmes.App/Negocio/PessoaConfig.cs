using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Negocio
{
    //Ele vira um classe de tipo genérico, onde esse tipo deve herdar de pessoa, 
    //assim pode ser usado por cliente e por funcionario
    public class PessoaConfig<T> : IEntityTypeConfiguration<T> where T : Pessoa
    {
        //tem que ser virtual pros filhos poderem sobrescrever
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
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

            builder
                .Property(a => a.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)");

            builder
                .Property(a => a.Ativo)
                .HasColumnName("active");

            //Shadow Property - tem na tabela, mas não tem na regra de negócio
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");
        }
    }
}