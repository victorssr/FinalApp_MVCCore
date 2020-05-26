using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Infra.Context;

namespace VSDev.Infra.Repositories
{
    public class CursoRepository : RepositoryBase<Curso>, ICursoRepository
    {
        public CursoRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
