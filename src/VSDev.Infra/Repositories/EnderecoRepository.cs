using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;
using VSDev.Infra.Context;

namespace VSDev.Infra.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
