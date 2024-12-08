using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.Database;
using app.Models.Entities;
using app.Models;

namespace app.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProducaoDeEnergiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducaoDeEnergiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/v2/ProducaoDeEnergia
        [HttpGet]
        public async Task<IActionResult> GetProducoes()
        {
            var producoes = await _context.ProducoesDeEnergia
                .Include(p => p.Usina)
                .ToListAsync();
           
            return Json(producoes);  
        }

        // GET: api/v2/ProducaoDeEnergia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducaoDeEnergia(Guid id)
        {
            var producaoDeEnergia = await _context.ProducoesDeEnergia
                .Include(p => p.Usina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producaoDeEnergia == null)
            {
                return NotFound();
            }
            return Ok(producaoDeEnergia);
        }

        // POST: api/v2/ProducaoDeEnergia
        [HttpPost]
        public async Task<IActionResult> CreateProducaoDeEnergia([FromBody] ProducaoDeEnergiaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var producaoDeEnergia = new ProducaoDeEnergia
                {
                    Id = Guid.NewGuid(),
                    Usina = await _context.Usinas.FindAsync(viewModel.UsinaId),
                    DataProducao = viewModel.DataProducao,
                    EnergiaGeradaKW = viewModel.EnergiaGeradaKW,
                    EficienciaOperacional = viewModel.EficienciaOperacional,
                    CreatedAt = DateTime.Now
                };

                _context.Add(producaoDeEnergia);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProducaoDeEnergia), new { id = producaoDeEnergia.Id }, producaoDeEnergia);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/v2/ProducaoDeEnergia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducaoDeEnergia(Guid id, [FromBody] ProducaoDeEnergiaViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var producaoDeEnergia = await _context.ProducoesDeEnergia.FindAsync(id);
                    if (producaoDeEnergia == null)
                    {
                        return NotFound();
                    }

                    producaoDeEnergia.Usina = await _context.Usinas.FindAsync(viewModel.UsinaId);
                    producaoDeEnergia.DataProducao = viewModel.DataProducao;
                    producaoDeEnergia.EnergiaGeradaKW = viewModel.EnergiaGeradaKW;
                    producaoDeEnergia.EficienciaOperacional = viewModel.EficienciaOperacional;
                    producaoDeEnergia.UpdatedAt = DateTime.Now;

                    _context.Update(producaoDeEnergia);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducaoDeEnergiaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/v2/ProducaoDeEnergia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducaoDeEnergia(Guid id)
        {
            var producaoDeEnergia = await _context.ProducoesDeEnergia.FindAsync(id);
            if (producaoDeEnergia == null)
            {
                return NotFound();
            }

            _context.ProducoesDeEnergia.Remove(producaoDeEnergia);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProducaoDeEnergiaExists(Guid id)
        {
            return _context.ProducoesDeEnergia.Any(e => e.Id == id);
        }
    }
}
