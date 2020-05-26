using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Infra.Configurations
{
    public static class EntityBaseConfiguration
    {

        public static void SetEntityBaseConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName)
            where TEntity : EntityBase
        {
            // DEFINIÇÕES DA TABELA
            builder.ToTable(tableName);
            builder.HasKey(b => b.Id);

            // CAMPOS PADRÕES
            builder.Property(b => b.Id)
                .HasColumnName("ID_" + tableName)
                .IsRequired();

            builder.Property(b => b.DataCadastro)
                .HasColumnName("DAT_CADASTRO")
                .IsRequired();
        }

    }
}
