using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaixaEletronicoAPI.Data;
using CaixaEletronicoAPI.Models;

namespace CaixaEletronicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaqueController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public SaqueController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Informe a id e o valor e retorna o valor do saque
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Saque(int id, decimal valor)
        {
            var conta = await _context.Conta.FindAsync(id);
            decimal saldo = conta.Saldo;
            decimal cpmf = 0.38m;
            decimal tarifa = 0;
            
            if(conta.TipoContaId == 1)
            {
                tarifa = (valor * cpmf) / 100;
            }
            else
            {
                tarifa = 0;
            }


            if (conta == null)
            {
                return NotFound();

            }else if(saldo >= valor)
            {
                conta.Saldo = saldo - valor - tarifa;

                await _context.SaveChangesAsync();

                return Ok(valor);
            }
            else
            {
                return Ok("Saldo insuficiente");
            }
        }
    }
}
