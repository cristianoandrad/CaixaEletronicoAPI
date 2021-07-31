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
    public class ContasController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public ContasController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Contas
        /// <summary>
        /// Retorna todas as contas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetConta()
        {
            return await _context.Conta.ToListAsync();
        }
        
       
        // GET: api/Contas/5
        /// <summary>
        /// Retorna a conta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            return conta;
            
        }

        /// <summary>
        /// Informe o id para alterar favorecido e o tipo da conta 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="favorecido"></param>
        /// <param name="tipoconta"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutConta(int id, int favorecido, int tipoconta)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (id != conta.Id)
            {
                return NotFound();
            }
            conta.FavorecidoId = favorecido;
            conta.TipoContaId = tipoconta;

            return Ok("Alteração Realizada");

        }

        // POST: api/Contas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Cadastro de contas
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            _context.Conta.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConta", new { id = conta.Id }, conta);
        }

        // DELETE: api/Contas/5
        /// <summary>
        /// Deleta a conta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }

            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }
    }
}
