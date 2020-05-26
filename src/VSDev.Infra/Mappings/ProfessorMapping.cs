using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;
using VSDev.Infra.Configurations;

namespace VSDev.Infra.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("PROFESSOR");

            // CAMPOS
            builder.Property(p => p.Nome)
                .HasColumnName("NOM_PROFESSOR")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Documento)
                .HasColumnName("NUM_DOCUMENTO")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DAT_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.Genero)
                .HasColumnName("NUM_GENERO")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("END_EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Celular)
                .HasColumnName("NUM_CELULAR")
                .HasMaxLength(14);
        }
    }
}
