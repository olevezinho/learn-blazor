using BlazorClientesNet10.Shared.Entities;
using BlazorClientesNet10.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorClientesNet10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ILogger<ClientesController> _logger;
    private readonly IClienteRepository _clienteRepository;

    public ClientesController(IClienteRepository clienteRepository, ILogger<ClientesController> logger)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> GetAllClientesAsync()
    {
        var clientes = await _clienteRepository.GetAllClientesAsync();
        return Ok(clientes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetClientesByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetClientesByIdAsync(id);
        if (cliente is null) return NotFound();
        return Ok(cliente);
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<Cliente>> AddClienteAsync([FromBody] Cliente model)
    {
        var cliente = await _clienteRepository.AddClienteAsync(model);
        if (cliente is null) return BadRequest("Cliente já existe.");
        return Ok(cliente);
    }

    [HttpPut("update")]
    public async Task<ActionResult<Cliente>> UpdateClienteAsync([FromBody] Cliente model)
    {
        var cliente = await _clienteRepository.UpdateClienteAsync(model);
        if (cliente is null) return BadRequest("Cliente já existe.");
        return Ok(cliente);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult<Cliente>> DeleteClientAsync(int id)
    {
        var cliente = await _clienteRepository.DeleteClientAsync(id);
        if (cliente is null) return NotFound();
        return Ok(cliente);
    }
}