using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.MVC.Data;
using VSDev.MVC.ViewModels;

namespace VSDev.MVC.Controllers
{
    [Authorize]
    public class ProfessoresController : Controller
    {
        private readonly IProfessorService _professorService;
        private readonly IMapper _mapper;

        public ProfessoresController(IProfessorService professorService, IMapper mapper)
        {
            _professorService = professorService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ProfessorViewModel>>(await _professorService.GetAll()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var professorViewModel = _mapper.Map<ProfessorViewModel>(await _professorService.GetById(id));

            if (professorViewModel == null) return NotFound();

            return View(professorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessorViewModel professorViewModel)
        {
            if (!ModelState.IsValid) return View(professorViewModel);

            await _professorService.Add(_mapper.Map<Professor>(professorViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var professorViewModel = _mapper.Map<ProfessorViewModel>(await _professorService.GetById(id));

            if (professorViewModel == null) return NotFound();

            return View(professorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProfessorViewModel professorViewModel)
        {
            if (id != professorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(professorViewModel);

            await _professorService.Update(_mapper.Map<Professor>(professorViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var professorViewModel = _mapper.Map<ProfessorViewModel>(await _professorService.GetById(id));

            if (professorViewModel == null) return NotFound();

            return View(professorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professor = await _professorService.GetById(id);

            if (professor == null) return NotFound();

            await _professorService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
