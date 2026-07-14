using AutoMapper;
using CoachFlow.Api.DTOs;
using CoachFlow.Api.Models;
using CoachFlow.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoachFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public ClientsController(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientDto>>> GetAll()
    {
        var clients = await _repository.GetAllAsync();
        return Ok(_mapper.Map<List<ClientDto>>(clients));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetById(int id)
    {
        var client = await _repository.GetByIdAsync(id);
        if (client is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ClientDto>(client));
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create(CreateClientDto createClientDto)
    {
        var client = _mapper.Map<Client>(createClientDto);
        client.StartedAt = DateTime.UtcNow;

        await _repository.AddAsync(client);
        await _repository.SaveChangesAsync();

        var clientDto = _mapper.Map<ClientDto>(client);
        return CreatedAtAction(nameof(GetById), new { id = client.Id }, clientDto);
    }
}
