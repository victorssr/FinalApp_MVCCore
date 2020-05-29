using System;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;

namespace VSDev.Business.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, INotificator notificator) : base(enderecoRepository, notificator)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> ObterEnderecoProfessor(Guid idProfessor)
        {
            return await _enderecoRepository.ObterEnderecoProfessor(idProfessor);
        }
    }
}
