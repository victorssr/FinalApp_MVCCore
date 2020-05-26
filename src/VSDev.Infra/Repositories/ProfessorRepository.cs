using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Infra.Context;

namespace VSDev.Infra.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
