﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VSDev.MVC.ViewModels
{
    public class EnderecoViewModel : EntityBaseViewModel
    {
        [DisplayName("Professor")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public Guid ProfessorId { get; set; }

        [StringLength(200, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [StringLength(10, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Numero { get; set; }

        [StringLength(10, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        public string Complemento { get; set; }

        [StringLength(200, ErrorMessage = "O {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Bairro { get; set; }

        [StringLength(200, ErrorMessage = "A {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public string Cidade { get; set; }

        [DisplayName("UF (Sigla)")]
        [StringLength(2, ErrorMessage = "A {0} deve ter até {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O {0} deve ter {1} caracteres")]
        [Required(ErrorMessage = "É necessário informar o {0}")]
        public string Cep { get; set; }

        // Relacionamento
        public ProfessorViewModel Professor { get; set; }

    }
}
