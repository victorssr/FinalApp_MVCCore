﻿using System;

namespace VSDev.Business.Models
{
    public class Endereco : EntityBase
    {
        public Guid ProfessorId { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        // Relacionamento
        public Professor Professor { get; set; }

    }
}
