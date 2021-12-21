using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class PedidoPromo
    {
        [Key]
        [Required]
        public int IdPedidoPromo { get; set; }

        //Criação da Fk Cliente
        [Required]
        public int ClienteIdCliente { get; set; }
        public Cliente Cliente { get; set; }

        //Criação da Fk Destino promocional
        [Required]
        public int DestinoPromoIdDestinoPromo { get; set; }
        public DestinoPromo DestinoPromo { get; set; }

    }
}
