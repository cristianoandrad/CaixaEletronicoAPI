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
    public class DepositarController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public DepositarController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }


        // PUT: api/Depositar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Informe o id da conta e o valor, retorna o valor do reposito
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Depositar(int id, decimal valor)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            decimal saltoAtual = conta.Saldo;
            decimal deposito = saltoAtual + valor;
            conta.Saldo = deposito;

            await _context.SaveChangesAsync();

            return Ok(valor);
        }
    }
}
