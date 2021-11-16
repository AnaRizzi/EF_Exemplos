using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    //em ver de herdar de IEntityTypeConfiguration herda de pessoaConfig, que já tem o começo da configuração
    public class ClienteConfig : PessoaConfig<Cliente>
    {
        //vai sobrescrever o método de PessoaConfig
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //chama a base para usar as configurações de PessoaConfig
            base.Configure(builder);

            builder
                .ToTable("customer");

            builder
                .Property(a => a.Id)
                .HasColumnName("customer_id");

            //Shadow Property - tem na tabela, mas não tem na regra de negócio
            builder
                .Property<DateTime>("create_date")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");
        }
    }
}