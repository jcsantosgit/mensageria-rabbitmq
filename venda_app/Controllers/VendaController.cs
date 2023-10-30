using Microsoft.AspNetCore.Mvc;
using venda_app.Data;
using venda_app.Models;

namespace venda_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly ILogger<VendaController> _logger;
    private readonly DataContext _context;

    public VendaController(ILogger<VendaController> logger, DataContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _context.Vendas.ToList();
        return Ok(list);
    }

    [HttpPost("realizar-venda")]
    public async Task<IActionResult> RealizarVenda(Venda model)
    {
        var service = "http://localhost:5093/api/estoque/reduzir/";
        _context.Vendas.Add(model);

        HttpResponseMessage message;

        using (var client = new HttpClient())
        {
            var response = await client.PostAsJsonAsync(service, new { 
                produto = model.IdProduto,
                quantidade = model.Quantidade
            });
            
            message = response.EnsureSuccessStatusCode();
        }

        _context.SaveChanges();
        return Ok("ok");
    }
}
