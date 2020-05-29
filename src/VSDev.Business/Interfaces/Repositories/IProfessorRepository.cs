using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSDev.Business.Models;

namespace VSDev.Business.Interfaces.Repositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>
    {
        Task<Professor> ObterProfessorEndereco(Guid id);
    }
}
