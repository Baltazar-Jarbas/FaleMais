using System;
using System.ComponentModel.DataAnnotations;

namespace FaleMais.Ui.Web.Models
{
    public class CalculoModel
    {
        [Required][Display(Name = "DDD Origem")] public string Origem { get; set; }
        [Required][Display(Name = "DDD Destino")] public string Destino { get; set; }
        [Required] [Display(Name = "Duração (min)")] public int Duracao { get; set; }
        [Required] [Display(Name = "Plano")] public Guid PlanoId { get; set; }
        public double Valor { get; set; }
        public double ValorFaleMais { get; set; } 
    }
}
