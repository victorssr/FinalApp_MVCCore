using Microsoft.EntityFrameworkCore;
using VSDev.Business.Models;

namespace VSDev.Infra.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Professor> Professor { get; set; }
    }
}
