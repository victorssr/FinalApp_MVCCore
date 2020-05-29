using System;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface IEnderecoService : IServiceBase<Endereco>
    {
        Task<Endereco> ObterEnderecoProfessor(Guid idProfessor);
    }
}
