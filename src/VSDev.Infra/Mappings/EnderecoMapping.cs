using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;
using VSDev.Infra.Configurations;

namespace VSDev.Infra.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("ENDERECO");
            builder.HasOne(p => p.Professor).WithOne(p => p.Endereco);

            // CAMPOS
            builder.Property(p => p.ProfessorId)
                .HasColumnName("ID_PROFESSOR")
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasColumnName("DSC_LOGRADOURO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnName("NUM_ENDERECO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Complemento)
                .HasColumnName("DSC_COMPLEMENTO")
                .HasMaxLength(10);

            builder.Property(p => p.Bairro)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnName("NUM_CEP")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
