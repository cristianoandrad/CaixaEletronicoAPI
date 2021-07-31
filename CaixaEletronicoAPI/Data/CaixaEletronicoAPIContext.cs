using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaixaEletronicoAPI.Models;

namespace CaixaEletronicoAPI.Data
{
    public class CaixaEletronicoAPIContext : DbContext
    {
        public CaixaEletronicoAPIContext (DbContextOptions<CaixaEletronicoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CaixaEletronicoAPI.Models.Conta> Conta { get; set; }

        public DbSet<CaixaEletronicoAPI.Models.Favorecido> Favorecido { get; set; }

        public DbSet<CaixaEletronicoAPI.Models.TipoConta> TipoConta { get; set; }
    }
}
