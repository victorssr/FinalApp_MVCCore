using AutoMapper;
using VSDev.Business.Models;
using VSDev.MVC.ViewModels;

namespace VSDev.MVC.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Professor, ProfessorViewModel>().ReverseMap();
            CreateMap<EntityBase, EntityBaseViewModel>().ReverseMap();
        }
    }
}
