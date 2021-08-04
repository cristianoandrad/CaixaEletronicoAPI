using CaixaEletronicoAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronicoAPI.Models;

namespace CaixaEletronicoAPI.Services
{
    public class ContasService
    {
        private CaixaEletronicoAPIContext dados;

        public ContasService(CaixaEletronicoAPIContext dados)
        {
            this.dados = dados;
        }

        public void PreencherTiposContasBasicas()
        {

            if (dados.TipoConta.Any())
            {
                return;
            }

            TipoConta contacorrete = new TipoConta(1, "Conta Corrente");
            TipoConta contapoupanca = new TipoConta(2, "Conta Poupanca");

            dados.TipoConta.AddRange(contacorrete, contapoupanca);

            dados.SaveChanges();

        }      


    }
}
