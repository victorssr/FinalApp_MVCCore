using System;
using System.ComponentModel.DataAnnotations;

namespace VSDev.MVC.ViewModels
{
    public abstract class EntityBaseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

    }
}
