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
    public class RendimentosController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public RendimentosController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Rendimentos da conta poupanca e retorna o rendimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Rendimentos(int id)
        {
            var conta = await _context.Conta.FindAsync(id);
            decimal saldo = conta.Saldo;
            decimal aliq = 0.87m;
            decimal rendi = 0;

            if (conta.TipoContaId == 2)
            {
                rendi = (saldo * aliq) / 100;
            }
            else
            {
                rendi = 0;
            }


            if (conta == null)
            {
                return NotFound();

            }


            conta.Saldo = saldo + rendi;

            await _context.SaveChangesAsync();

            return Ok(rendi);


        }
    }
}
