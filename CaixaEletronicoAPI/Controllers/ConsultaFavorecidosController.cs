using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaixaEletronicoAPI.Data;
using CaixaEletronicoAPI.Models;

namespace CaixaEletronicoAPI.Controllers
{
    public class ConsultaFavorecidosController : Controller
    {
        private readonly CaixaEletronicoAPIContext _context;

        public ConsultaFavorecidosController(CaixaEletronicoAPIContext context)
        {
            _context = context;
        }

        // GET: ConsultaFavorecidos
        [HttpGet("{nome}")]
        public async Task<ActionResult<Favorecido>> GetFavorecidos(string nome)
        {
            var favorecido = await _context.Favorecido.Where(x => x.Nome == nome).FirstOrDefaultAsync();
            return favorecido;
        }
    }
}
