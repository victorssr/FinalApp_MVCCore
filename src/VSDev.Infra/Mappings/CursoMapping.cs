using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;
using VSDev.Infra.Configurations;

namespace VSDev.Infra.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            // TABELA
            builder.SetEntityBaseConfiguration("CURSO");
            builder.HasOne(p => p.Professor).WithMany(p => p.Cursos).HasForeignKey(p => p.ProfessorId);

            // CAMPOS
            builder.Property(p => p.ProfessorId)
                .HasColumnName("ID_PROFESSOR")
                .IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnName("DSC_TITULO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_CURSO")
                .HasColumnType("NTEXT")
                .IsRequired();

            builder.Property(p => p.ImagemCapa)
                .HasColumnName("NOM_IMAGEM")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VLR_CURSO")
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("IND_ATIVO")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("QTD_DURACAO")
                .IsRequired();
        }
    }
}
