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
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<Professor> ObterProfessorEndereco(Guid id)
        {
            return await _contextBase.Professores.AsNoTracking()
                    .Include(p => p.Endereco).Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }
    }
}
