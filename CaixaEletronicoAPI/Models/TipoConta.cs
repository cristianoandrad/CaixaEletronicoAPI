using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoAPI.Models
{
    public class TipoConta
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public TipoConta(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
