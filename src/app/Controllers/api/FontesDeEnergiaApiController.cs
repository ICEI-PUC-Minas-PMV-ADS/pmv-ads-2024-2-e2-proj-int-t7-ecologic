using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.Database;
using app.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Controllers.api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FontesDeEnergiaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FontesDeEnergiaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/v2/Fontes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FonteDeEnergia>>> GetFontesDeEnergia()
        {
            var fontes = await _dbContext.FontesDeEnergia
                              .OrderByDescending(f => f.CreatedAt) // Ordena pelo campo CreatedAt de forma decrescente
                              .ToListAsync();
            return Ok(fontes);
        }

        // GET: api/v2/Fontes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FonteDeEnergia>> GetFonteDeEnergia(Guid id)
        {
            var fonte = await _dbContext.FontesDeEnergia.FindAsync(id);
            if (fonte == null)
            {
                return NotFound();
            }

            return Ok(fonte);
        }

        // POST: api/v2/Fontes
        [HttpPost]
        public async Task<ActionResult<FonteDeEnergia>> PostFonteDeEnergia([FromBody] FonteDeEnergia fonte)
        {
            if (fonte == null)
            {
                return BadRequest("Fonte de Energia inválida.");
            }

            _dbContext.FontesDeEnergia.Add(fonte);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFonteDeEnergia), new { id = fonte.Id }, fonte);
        }

        // PUT: api/v2/Fontes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFonteDeEnergia(Guid id, [FromBody] FonteDeEnergia fonte)
        {
            if (id != fonte.Id)
            {
                return BadRequest("ID não corresponde.");
            }

            var fonteExistente = await _dbContext.FontesDeEnergia.FindAsync(id);
            if (fonteExistente == null)
            {
                return NotFound();
            }

            fonteExistente.Tipo = fonte.Tipo;
            fonteExistente.EficienciaMedia = fonte.EficienciaMedia;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/v2/Fontes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFonteDeEnergia(Guid id)
        {
            var fonte = await _dbContext.FontesDeEnergia.FindAsync(id);
            if (fonte == null)
            {
                return NotFound();
            }

            _dbContext.FontesDeEnergia.Remove(fonte);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
