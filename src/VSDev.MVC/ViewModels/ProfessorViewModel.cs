using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VSDev.Business.Models.Enumerations;
using VSDev.MVC.Extensions;

namespace VSDev.MVC.ViewModels
{
    public class ProfessorViewModel : EntityBaseViewModel
    {
        [StringLength(300, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Nome { get; set; }

        [DisplayName("Documento (CPF ou CNPJ)")]
        [Documento]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O {0} deve ter {2} ou {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Documento { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public int? Genero { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Email { get; set; }

        [DisplayName("Número do celular")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O {0} deve ter {1} caracteres")]
        public string Celular { get; set; }

        // Relacionamento
        public EnderecoViewModel Endereco { get; set; }
        public List<CursoViewModel> Cursos { get; set; }
    }

}
