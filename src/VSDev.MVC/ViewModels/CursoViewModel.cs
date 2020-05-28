using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VSDev.MVC.Extensions.Attributes;

namespace VSDev.MVC.ViewModels
{
    public class CursoViewModel : EntityBaseViewModel
    {

        [DisplayName("Professor")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public Guid ProfessorId { get; set; }

        [DisplayName("Título")]
        [StringLength(300, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public string Descricao { get; set; }

        [DisplayName("Capa do Curso")]
        public string ImagemCapa { get; set; }

        [ScaffoldColumn(false)]
        public decimal Valor { get; set; }

        [DisplayName("Ativo?")]
        [Required(ErrorMessage = "É necessário informar o status de ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Duração do curso (Em horas)")]
        [Range(1, int.MaxValue, ErrorMessage = "É necessário informar a {0}")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public int? DuracaoEmHoras { get; set; }

        // RELACIONAMENTO
        public ProfessorViewModel Professor { get; set; }

        // AUXILIAR

        [DisplayName("Valor")]
        [Decimal(AllowZero = true, Prefix = "R$")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string ValorCurrency { get; set; }

        public IEnumerable<ProfessorViewModel> Professores { get; set; }

        [DisplayName("Capa do Curso")]
        public IFormFile UploadCapa { get; set; }
    }
}
