using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class Suporte
    {
        [Key]
        [Required]
        public int IdSuporte { get; set; }
        [Required(ErrorMessage = "Escreva a mensagem...")]
        public string Mensagem { get; set; }
        //Criação da FK Cliente
        [Required]
        public int ClienteIdCliente { get; set; }
        public Cliente Cliente { get; set; }



    }
}
