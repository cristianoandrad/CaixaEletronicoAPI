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
    public class FavorecidosController : ControllerBase
    {
        private readonly CaixaEletronicoAPIContext _context;

        public FavorecidosController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Favorecidoes
        /// <summary>
        /// Retorna todos os favorecidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorecido>>> GetFavorecido()
        {
            return await _context.Favorecido.ToListAsync();
        }

        // GET: api/Favorecidoes/5
        /// <summary>
        /// Retorna o favorecido pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorecido>> GetFavorecido(int id)
        {
            var favorecido = await _context.Favorecido.FindAsync(id);

            if (favorecido == null)
            {
                return NotFound();
            }

            return favorecido;
        }

        // PUT: api/Favorecidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Altera o favorecido pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="favorecido"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorecido(int id, Favorecido favorecido)
        {
            if (id != favorecido.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorecido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavorecidoExists(id))
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

        // POST: api/Favorecidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Adiciona favorecidos
        /// </summary>
        /// <param name="favorecido"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Favorecido>> PostFavorecido(Favorecido favorecido)
        {
            _context.Favorecido.Add(favorecido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorecido", new { id = favorecido.Id }, favorecido);
        }

        // DELETE: api/Favorecidoes/5
        /// <summary>
        /// Deleta favorecido por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorecido(int id)
        {
            var favorecido = await _context.Favorecido.FindAsync(id);
            if (favorecido == null)
            {
                return NotFound();
            }

            _context.Favorecido.Remove(favorecido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavorecidoExists(int id)
        {
            return _context.Favorecido.Any(e => e.Id == id);
        }
    }
}
