using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Informe seu nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe seu CPF!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe seu Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe seu número de telefone!")]
        public string Telefone { get; set; }

    }
}
