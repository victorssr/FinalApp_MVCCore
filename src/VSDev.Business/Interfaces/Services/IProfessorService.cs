using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Services
{
    public interface IProfessorService : IServiceBase<Professor>
    {
        Task<Professor> ObterProfessorEndereco(Guid id);
    }
}
