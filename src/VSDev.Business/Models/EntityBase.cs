using System;

namespace VSDev.Business.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

    }
}
