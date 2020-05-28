using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Models;
using VSDev.Business.Notifications;
using VSDev.MVC.ViewModels;

namespace VSDev.MVC.Controllers
{

    [Authorize]
    public class CursosController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursosController(ICursoService cursoService, IMapper mapper, INotificator notificator, IProfessorService professorService)
            : base(notificator)
        {
            _cursoService = cursoService;
            _mapper = mapper;
            _professorService = professorService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CursoViewModel>>(await _cursoService.ListarProfessores()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var cursoViewModel = await ObterCursoProfessor(id);

            if (cursoViewModel == null) return NotFound();

            return View(cursoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View(await PopularProfessores(new CursoViewModel()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CursoViewModel cursoViewModel)
        {
            cursoViewModel = await PopularProfessores(cursoViewModel);
            if (!ModelState.IsValid) return View(cursoViewModel);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(cursoViewModel.UploadCapa.FileName);
            if (!await UploadArquivo(cursoViewModel.UploadCapa, fileName, cursoViewModel.ImagemCapa)) return View(cursoViewModel);

            cursoViewModel.Valor = Decimal.Parse(ObterNumeroDecimal(cursoViewModel.ValorCurrency), new CultureInfo("pt-BR"));
            cursoViewModel.ImagemCapa = fileName;
            await _cursoService.Add(_mapper.Map<Curso>(cursoViewModel));

            if (!OperacaoValida()) return View(cursoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var cursoViewModel = await ObterCursoProfessor(id);

            if (cursoViewModel == null) return NotFound();

            return View(cursoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CursoViewModel cursoViewModel)
        {
            if (id != cursoViewModel.Id) return NotFound();

            var produtoBase = await ObterCursoProfessor(id);
            if (produtoBase == null) return NotFound();

            cursoViewModel.ImagemCapa = produtoBase.ImagemCapa;
            cursoViewModel.Professores = produtoBase.Professores;
            if (!ModelState.IsValid) return View(cursoViewModel);

            if (cursoViewModel.UploadCapa != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(cursoViewModel.UploadCapa.FileName);
                if (!await UploadArquivo(cursoViewModel.UploadCapa, fileName, cursoViewModel.ImagemCapa)) return View(cursoViewModel);
                cursoViewModel.ImagemCapa = fileName;
            }

            cursoViewModel.Valor = Decimal.Parse(ObterNumeroDecimal(cursoViewModel.ValorCurrency), new CultureInfo("pt-BR"));

            await _cursoService.Update(_mapper.Map<Curso>(cursoViewModel));

            if (!OperacaoValida()) return View(cursoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var cursoViewModel = await ObterCursoProfessor(id);

            if (cursoViewModel == null) return NotFound();

            return View(cursoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cursoViewModel = await ObterCursoProfessor(id);

            if (cursoViewModel == null) return NotFound();

            await _cursoService.Remove(id);

            if (!OperacaoValida()) return View(cursoViewModel);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CursoViewModel> ObterCursoProfessor(Guid id)
        {
            var cursoViewModel = _mapper.Map<CursoViewModel>(await _cursoService.ObterCursoProfessor(id));
            cursoViewModel = await PopularProfessores(cursoViewModel);
            return cursoViewModel;
        }

        private async Task<CursoViewModel> PopularProfessores(CursoViewModel cursoViewModel)
        {
            cursoViewModel.Professores = _mapper.Map<IEnumerable<ProfessorViewModel>>(await _professorService.GetAll());
            return cursoViewModel;
        }

        private string ObterNumeroDecimal(string value)
        {
            string valueNumber = "";

            foreach (char c in value.ToCharArray())
            {
                if (Char.IsNumber(c) || new char[] { '.', ',' }.Contains(c))
                {
                    valueNumber += c;
                }
            }

            return valueNumber;
        }

        private async Task<bool> UploadArquivo(IFormFile file, string fileName, string oldFileName = "")
        {
            if (file.Length <= 0)
            {
                ViewData.ModelState.AddModelError("", "É necessário selecionar um arquivo");
                return false;
            }

            if (!string.IsNullOrEmpty(oldFileName))
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/curso", oldFileName);
                System.IO.File.Delete(oldPath);
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/curso", fileName);
            if (System.IO.File.Exists(path))
            {
                ViewData.ModelState.AddModelError("", "Ocorreu um problema, por favor tente novamente.");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
