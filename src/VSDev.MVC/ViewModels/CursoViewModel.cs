using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.MVC.ViewModels
{
    public class CursoViewModel : EntityBaseViewModel
    {
        [Required]
        public Guid ProfessorId { get; set; }

        [DisplayName("Título")]
        [StringLength(300, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required]
        public string Descricao { get; set; }

        [DisplayName("Capa do Curso")]
        [StringLength(100, ErrorMessage = "A {0} deve ter até {1} caracteres")]
        [Required]
        public string ImagemCapa { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [DisplayName("Ativo?")]
        [Required]
        public bool Ativo { get; set; }

        [DisplayName("Duração do curso (Em horas)")]
        [Required]
        public int DuracaoEmHoras { get; set; }

        // Relacionamento
        public ProfessorViewModel Professor { get; set; }
    }
}
