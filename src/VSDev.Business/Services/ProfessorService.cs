﻿using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Models;

namespace VSDev.Business.Services
{
    public class ProfessorService : ServiceBase<Professor>
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            _professorRepository = professorRepository;
        }
    }
}
