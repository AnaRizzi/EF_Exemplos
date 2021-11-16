using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.Filmes.App.Dados
{
    //em ver de herdar de IEntityTypeConfiguration herda de pessoaConfig, que já tem o começo da configuração
    public class FuncionarioConfig : PessoaConfig<Funcionario>
    {
        //vai sobrescrever o método de PessoaConfig
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //chama a base para usar as configurações de PessoaConfig
            base.Configure(builder);

            builder
                .ToTable("staff");

            builder
                .Property(a => a.Id)
                .HasColumnName("staff_id");

            builder
                .Property(a => a.Login)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder
                .Property(a => a.Senha)
                .HasColumnName("password")
                .HasColumnType("varchar(16)");
        }
    }
}