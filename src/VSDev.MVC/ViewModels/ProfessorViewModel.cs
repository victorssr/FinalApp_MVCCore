using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VSDev.Business.Models.Enumerations;

namespace VSDev.MVC.ViewModels
{
    public class ProfessorViewModel : EntityBaseViewModel
    {
        [StringLength(300, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required]
        public string Nome { get; set; }

        [DisplayName("Documento (CPF ou CNPJ)")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O {0} deve ter {2} ou {1} caracteres")]
        [Required]
        public string Documento { get; set; }

        [DisplayName("Data de nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Gênero")]
        [Required]
        public Genero Genero { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Número do celular")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O {0} deve ter {1} caracteres")]
        [Required]
        public string Celular { get; set; }

        // Relacionamento
        public EnderecoViewModel Endereco { get; set; }
        public List<CursoViewModel> Cursos { get; set; }
    }

}
