using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class CursoService : ServiceBase<Curso>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository) : base(cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
    }
}
