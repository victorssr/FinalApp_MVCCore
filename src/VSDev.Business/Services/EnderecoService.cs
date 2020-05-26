using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class EnderecoService : ServiceBase<Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
    }
}
