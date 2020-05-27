using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Services;
using VSDev.Infra.Context;
using VSDev.Infra.Repositories;
using VSDev.MVC.Extensions;

namespace VSDev.MVC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDepedencies(this IServiceCollection services)
        {
            //services.AddScoped<ContextBase>();

            services.AddSingleton<IValidationAttributeAdapterProvider, DocumentoValidationAttributeAdapterProvider>();

            // REPOSITORIES
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            // SERVICES
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IProfessorService, ProfessorService>();

            return services;
        }
    }
}
