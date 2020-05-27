using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100, ErrorMessage = "A {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public string ImagemCapa { get; set; }

        [Required(ErrorMessage = "É necessário informar o {0}")]
        public decimal Valor { get; set; }

        [DisplayName("Ativo?")]
        [Required(ErrorMessage = "É necessário informar o status de ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Duração do curso (Em horas)")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public int DuracaoEmHoras { get; set; }

        // Relacionamento
        public ProfessorViewModel Professor { get; set; }
    }
}
