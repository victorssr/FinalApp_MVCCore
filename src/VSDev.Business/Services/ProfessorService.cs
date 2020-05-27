using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;

namespace VSDev.Business.Services
{
    public class ProfessorService : ServiceBase<Professor>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository, INotificator notificator)
            : base(professorRepository, notificator)
        {
            _professorRepository = professorRepository;
        }

        public override async Task Add(Professor entity)
        {
            if (_professorRepository.Find(p => p.Email == entity.Email).Result.Any()) 
                Notificar("Já existe um professor cadastrado com o e-mail informado.");

            if (_professorRepository.Find(p => p.Documento == entity.Documento).Result.Any()) 
                Notificar("Já existe um professor cadastrado com o documento informado.");

            if (PossuiNotificacao())
                return;

            await base.Add(entity);
        }

        public override async Task Update(Professor entity)
        {
            if (_professorRepository.Find(p => p.Email == entity.Email && p.Id != entity.Id).Result.Any())
                Notificar("Já existe um professor cadastrado com o e-mail informado.");

            if (_professorRepository.Find(p => p.Documento == entity.Documento && p.Id != entity.Id).Result.Any())
                Notificar("Já existe um professor cadastrado com o documento informado.");

            if (PossuiNotificacao())
                return;

            await base.Update(entity);
        }
    }
}
