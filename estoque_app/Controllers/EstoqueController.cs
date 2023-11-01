using estoque_app.Data;
using estoque_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace estoque_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstoqueController : ControllerBase
{
    private readonly ILogger<EstoqueController> _logger;
    private readonly DataContext _context;

    public EstoqueController(ILogger<EstoqueController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        try
        {
            var list = _context.Estoques.ToList();
            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("Ocorreu um erro interno");
        }
    }

    [HttpPost("reduzir")]
    public IActionResult ReduzirEstoque(EstoqueRequest model)
    {
        try
        {
            var entity = _context.Estoques.First(c => c.IdProduto == model.Produto);
            entity.Quantidade = entity.Quantidade - model.Quantidade;
            _context.SaveChanges();
            return Ok("Atualizado");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("Ocorreu um erro interno");
        }
    }

    [HttpPost("aumentar")]
    public IActionResult AumentarEstoque(EstoqueRequest model)
    {
        try
        {
            var entity = _context.Estoques.First(c => c.IdProduto == model.Produto);
            entity.Quantidade = entity.Quantidade + model.Quantidade;
            _context.SaveChanges();
            return Ok("Atualizado");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("Ocorreu um erro interno");
        }
    }    
}
