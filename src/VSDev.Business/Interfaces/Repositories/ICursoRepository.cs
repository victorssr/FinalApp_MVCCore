using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface ICursoRepository : IRepositoryBase<Curso>
    {
        Task<IEnumerable<Curso>> ListarProfessores();
        Task<Curso> ObterCursoProfessor(Guid id);
    }
}
