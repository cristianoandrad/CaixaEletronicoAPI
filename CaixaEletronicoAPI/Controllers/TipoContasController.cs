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
    public class TipoContasController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public TipoContasController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }


        // GET: api/TipoContas
        /// <summary>
        /// Retorna todos os tipos de contas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoConta>>> GetTipoConta()
        {
            return await _context.TipoConta.ToListAsync();
        }

        // GET: api/TipoContas/5
        /// <summary>
        /// Retorna o tipo de conta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoConta>> GetTipoConta(int id)
        {
            var tipoConta = await _context.TipoConta.FindAsync(id);

            if (tipoConta == null)
            {
                return NotFound();
            }

            return tipoConta;
        }

        // PUT: api/TipoContas/5        
        /// <summary>
        /// Altera o tipo de conta por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoConta"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoConta(int id, TipoConta tipoConta)
        {
            if (id != tipoConta.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoConta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoContaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoContas
        /// <summary>
        /// Cria tipos de contas
        /// </summary>
        /// <param name="tipoConta"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TipoConta>> PostTipoConta(TipoConta tipoConta)
        {
            _context.TipoConta.Add(tipoConta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoConta", new { id = tipoConta.Id }, tipoConta);
        }

        // DELETE: api/TipoContas/5
        /// <summary>
        /// Deletar tipo de conta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoConta(int id)
        {
            var tipoConta = await _context.TipoConta.FindAsync(id);
            if (tipoConta == null)
            {
                return NotFound();
            }

            _context.TipoConta.Remove(tipoConta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoContaExists(int id)
        {
            return _context.TipoConta.Any(e => e.Id == id);
        }
    }
}
