using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private readonly ICursoRepository _cursoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ProfessorService(IProfessorRepository professorRepository, INotificator notificator, ICursoRepository cursoRepository, IEnderecoRepository enderecoRepository)
            : base(professorRepository, notificator)
        {
            _professorRepository = professorRepository;
            _cursoRepository = cursoRepository;
            _enderecoRepository = enderecoRepository;
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

        public override async Task Remove(Guid id)
        {
            var cursosProfessor = await _cursoRepository.BuscarCursosProfessor(id);
            await _cursoRepository.RemoveInScale(cursosProfessor.ToList());

            var enderecoProfessor = await _enderecoRepository.ObterEnderecoProfessor(id);
            if (enderecoProfessor != null) await _enderecoRepository.Remove(enderecoProfessor.Id);

            await base.Remove(id);
        }

        public async Task<Professor> ObterProfessorEndereco(Guid id)
        {
            return await _professorRepository.ObterProfessorEndereco(id);
        }

        public async Task<Professor> ObterProfessorEnderecoCursos(Guid id)
        {
            return await _professorRepository.ObterProfessorEnderecoCursos(id);
        }
    }
}
