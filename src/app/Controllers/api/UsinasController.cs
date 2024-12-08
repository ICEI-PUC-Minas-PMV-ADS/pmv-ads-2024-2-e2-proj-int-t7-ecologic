using app.Database;
using app.Models;
using app.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers.Api
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsinasController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UsinasController> _logger;

        public UsinasController(ILogger<UsinasController> logger, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // Retorna todas as usinas com seus detalhes
        [HttpGet]
        public async Task<IActionResult> GetUsinas()
        {
            try
            {
                var usinas = await _dbContext.Usinas
                    .Include(u => u.FonteDeEnergia)
                    .Include(u => u.Cidade)
                    .Include(u => u.Cliente)
                    .ToListAsync();

                return Ok(usinas); // Retorna 200 OK com a lista de usinas
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar usinas: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor"); // Retorna erro 500 em caso de falha
            }
        }

        // Retorna uma usina específica por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsina(Guid id)
        {
            try
            {
                var usina = await _dbContext.Usinas
                    .Include(u => u.FonteDeEnergia)
                    .Include(u => u.Cidade)
                    .Include(u => u.Cliente)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (usina == null)
                {
                    return NotFound(new { Message = "Usina não encontrada." }); // Retorna 404 se não encontrar
                }

                return Ok(usina); // Retorna 200 OK com a usina encontrada
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar usina com ID {id}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // Cria uma nova usina
        [HttpPost]
        public async Task<IActionResult> CreateUsina([FromBody] AddUsinaViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest("Dados da usina são inválidos."); // Retorna 400 se os dados forem inválidos
            }

            try
            {
                var cidade = await _dbContext.Cidades.FindAsync(viewModel.CidadeId);
                var cliente = await _dbContext.Clientes.FindAsync(viewModel.ClienteId);
                var fonteDeEnergia = await _dbContext.FontesDeEnergia.FindAsync(viewModel.FonteDeEnergiaId);

                if (cidade == null || cliente == null || fonteDeEnergia == null)
                {
                    return NotFound(new { Message = "Cidade, cliente ou fonte de energia não encontrada." }); // 404 se alguma dependência não existir
                }

                var usina = new Usina
                {
                    Nome = viewModel.Nome,
                    Cidade = cidade,
                    Cliente = cliente,
                    FonteDeEnergia = fonteDeEnergia,
                    StatusOperacional = viewModel.StatusOperacional,
                    Endereco = viewModel.Endereco,
                    DataInicio = viewModel.DataInicio,
                    CapacidadeKW = viewModel.CapacidadeKW
                };

                await _dbContext.Usinas.AddAsync(usina);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsina), new { id = usina.Id }, usina); // 201 Created
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar usina: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // Atualiza uma usina existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsina(Guid id, [FromBody] EditUsinaViewModel viewModel)
        {
            if (viewModel.Id != id)
            {
                return BadRequest("IDs não coincidem.");
            }

            try
            {
                var usina = await _dbContext.Usinas.FindAsync(id);
                if (usina == null)
                {
                    return NotFound(new { Message = "Usina não encontrada." });
                }

                usina.Nome = viewModel.Nome;
                usina.CapacidadeKW = viewModel.CapacidadeKW;
                usina.DataInicio = viewModel.DataInicio;
                usina.StatusOperacional = viewModel.StatusOperacional;
                usina.Endereco = viewModel.Endereco;
                usina.Cidade = await _dbContext.Cidades.FindAsync(viewModel.CidadeId);
                usina.Cliente = await _dbContext.Clientes.FindAsync(viewModel.ClienteId);
                usina.FonteDeEnergia = await _dbContext.FontesDeEnergia.FindAsync(viewModel.FonteDeEnergiaId);

                _dbContext.Update(usina);
                await _dbContext.SaveChangesAsync();

                return Ok(usina); // Retorna a usina atualizada
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar usina com ID {id}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // Deleta uma usina
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsina(Guid id)
        {
            try
            {
                var usina = await _dbContext.Usinas.FindAsync(id);
                if (usina == null)
                {
                    return NotFound(new { Message = "Usina não encontrada." });
                }

                _dbContext.Usinas.Remove(usina);
                await _dbContext.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content após a exclusão
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar usina com ID {id}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
