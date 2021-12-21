using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class DestinoPromo
    {
        [Key]
        [Required]
        public int IdDestinoPromo { get; set; }
        [Required]
        public string NomeDestinoPromo { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public decimal PrecoUnitarioPromo { get; set; }
        public string UrlImagemPromo { get; set; }
    }
}
