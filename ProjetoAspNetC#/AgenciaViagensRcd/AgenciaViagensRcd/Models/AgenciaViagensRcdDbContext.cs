using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagensRcd.Models
{
    public class AgenciaViagensRcdDbContext : DbContext
    {
        public AgenciaViagensRcdDbContext(DbContextOptions<AgenciaViagensRcdDbContext> opt) : base(opt) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<DestinoPromo> DestinoPromo { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoPromo> PedidoPromo { get; set; }
        public DbSet<Suporte> Suporte { get; set; }

    }
}
