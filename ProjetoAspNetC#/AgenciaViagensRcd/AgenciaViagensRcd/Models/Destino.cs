using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class Destino
    {
        [Key]
        [Required]
        public int IdDestino { get; set; }
        [Required]
        public string NomeDestino { get; set; }
        [Required]
        public decimal PrecoUnitario { get; set; }
        public string UrlImagem { get; set; }

    }
}
