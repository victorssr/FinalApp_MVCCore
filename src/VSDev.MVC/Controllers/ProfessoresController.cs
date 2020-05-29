using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;
using VSDev.MVC.ViewModels;

namespace VSDev.MVC.Controllers
{
    [Authorize]
    public class ProfessoresController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly IEnderecoService _enderecoService;
        private readonly IProfessorService _professorService;
        private readonly IMapper _mapper;

        public ProfessoresController(IProfessorService professorService, IMapper mapper, INotificator notificator, IEnderecoService enderecoService, ICursoService cursoService) : base(notificator)
        {
            _professorService = professorService;
            _mapper = mapper;
            _enderecoService = enderecoService;
            _cursoService = cursoService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ProfessorViewModel>>(await _professorService.GetAll()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var professorViewModel = await ObterProfessorEndereco(id);

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

            if (!OperacaoValida()) return View(professorViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var professorViewModel = await ObterProfessorEnderecoCursos(id);

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

            if (!OperacaoValida()) return View(professorViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var professorViewModel = await ObterProfessorEndereco(id);

            if (professorViewModel == null) return NotFound();

            return View(professorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professor = await _professorService.FindAsNoTracking(id);
            if (professor == null) return NotFound();

            await _professorService.Remove(id);

            if (!OperacaoValida()) return View(_mapper.Map<ProfessorViewModel>(professor));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var professorViewModel = await ObterProfessorEndereco(id);

            if (professorViewModel == null) return NotFound();

            return PartialView("_AtualizarEndereco", new ProfessorViewModel { Endereco = professorViewModel.Endereco });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(ProfessorViewModel professorViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Email");
            ModelState.Remove("Genero");
            ModelState.Remove("Documento");
            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", professorViewModel);

            var endereco = _mapper.Map<Endereco>(professorViewModel.Endereco);
            await _enderecoService.Update(endereco);

            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", professorViewModel);

            var url = Url.Action("ObterEndereco", "Professores", new { id = professorViewModel.Endereco.ProfessorId });
            return Json(new { success = true, url });
        }

        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var professorViewModel = await ObterProfessorEndereco(id);

            if (professorViewModel == null) return NotFound();

            return PartialView("_DetalhesEndereco", professorViewModel);
        }

        private async Task<ProfessorViewModel> ObterProfessorEndereco(Guid id)
        {
            var professorViewModel = _mapper.Map<ProfessorViewModel>(await _professorService.ObterProfessorEndereco(id));
            return professorViewModel;
        }


        private async Task<ProfessorViewModel> ObterProfessorEnderecoCursos(Guid id)
        {
            return _mapper.Map<ProfessorViewModel>(await _professorService.ObterProfessorEnderecoCursos(id));
        }

    }
}
