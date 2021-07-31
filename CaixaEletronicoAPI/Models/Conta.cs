using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoAPI.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int Agencia { get; set; }
        public long Numero { get; set; }
        public decimal Saldo { get; set; }
        public int FavorecidoId { get; set; }
        public Favorecido Favorecido { get; set; }
        public int TipoContaId { get; set; }
        public TipoConta TipoConta { get; set; }

        public decimal RetornaSaldo()
        {
            return this.Saldo;
        }
    }
}
