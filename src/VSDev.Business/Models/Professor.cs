using System;
using System.Collections.Generic;

namespace VSDev.Business.Models
{
    public class Professor : EntityBase
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        // Relacionamento
        public Endereco Endereco { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
