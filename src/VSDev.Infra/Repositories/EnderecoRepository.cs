using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Infra.Context;

namespace VSDev.Infra.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<Endereco> ObterEnderecoProfessor(Guid idProfessor)
        {
            return await _contextBase.Enderecos.AsNoTracking()
                        .FirstOrDefaultAsync(e => e.ProfessorId == idProfessor);
        }
    }
}
