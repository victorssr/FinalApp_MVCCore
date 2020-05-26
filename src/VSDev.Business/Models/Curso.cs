namespace VSDev.Business.Models
{
    public class Curso : EntityBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemCapa { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public int DuracaoEmHoras { get; set; }

        // Relacionamento
        public Professor Professor { get; set; }
    }
}
