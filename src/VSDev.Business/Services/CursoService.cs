using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;

namespace VSDev.Business.Services
{
    public class CursoService : ServiceBase<Curso>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository, INotificator notificator) : base(cursoRepository, notificator)
        {
            _cursoRepository = cursoRepository;
        }
    }
}
