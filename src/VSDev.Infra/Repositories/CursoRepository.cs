using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Infra.Context;

namespace VSDev.Infra.Repositories
{
    public class CursoRepository : RepositoryBase<Curso>, ICursoRepository
    {
        public CursoRepository(ContextBase contextBase) : base(contextBase) { }


        public async Task<IEnumerable<Curso>> ListarProfessores()
        {
            return await _contextBase.Cursos.AsNoTracking().Include(c => c.Professor).ToListAsync();
        }

        public async Task<Curso> ObterCursoProfessor(Guid id)
        {
            return await _contextBase.Cursos.AsNoTracking()
                .Include(c => c.Professor).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Curso>> BuscarCursosProfessor(Guid professorId)
        {
            return await _contextBase.Cursos.AsNoTracking()
                            .Where(c => c.ProfessorId == professorId).ToListAsync();
        }
    }
}
