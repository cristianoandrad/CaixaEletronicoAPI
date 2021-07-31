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
    public class TransferenciaController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public TransferenciaController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Informar id das contas e valor, retorna valor da tranferencia
        /// </summary>
        /// <param name="id_origem"></param>
        /// <param name="id_destino"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Transferencia(int id_origem, int id_destino, decimal valor)
        {
            var contaOrigem = await _context.Conta.FindAsync(id_origem);
            var contaDestino = await _context.Conta.FindAsync(id_destino);
            decimal saldoOrigem = contaOrigem.Saldo;
            decimal saldoDestino = contaDestino.Saldo;

            if (contaOrigem == null && contaDestino == null)
            {
                return NotFound();
            } else if (saldoOrigem >= valor)
            {
                contaOrigem.Saldo = saldoOrigem - valor;
                contaDestino.Saldo = saldoDestino + valor;
                await _context.SaveChangesAsync();
                return Ok(valor);
            }
            else
            {
                return Ok("Conta sem saldo");
            }             
                        
        }
    }
}
