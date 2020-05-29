using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface ICursoService : IServiceBase<Curso>
    {
        Task<IEnumerable<Curso>> ListarProfessores();
        Task<Curso> ObterCursoProfessor(Guid id);
        Task<IEnumerable<Curso>> BuscarCursosProfessor(Guid professorId);
    }
}
