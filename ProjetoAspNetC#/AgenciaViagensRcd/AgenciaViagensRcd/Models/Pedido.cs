using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int IdPedido { get; set; }

        //Criação da Fk Cliente
        [Required]
        public int ClienteIdCliente { get; set; }
        public Cliente Cliente { get; set; }

        //Criação da Fk Destino
        [Required]
        public int DestinoIdDestino { get; set; }
        public Destino Destino { get; set; }

      

    }
}
