using AutoMapper;
using CoachFlow.Api.DTOs;
using CoachFlow.Api.Models;
using CoachFlow.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoachFlow.Api.Controllers;

[ApiController]
[Route("api/clients/{clientId}/sessions")]
public class SessionsController : ControllerBase
{
    private readonly ISessionRepository _repository;
    private readonly IMapper _mapper;

    public SessionsController(ISessionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<SessionDto>>> GetByClientId(int clientId)
    {
        var sessions = await _repository.GetByClientIdAsync(clientId);
        return Ok(_mapper.Map<List<SessionDto>>(sessions));
    }

    [HttpPost]
    public async Task<ActionResult<SessionDto>> Create(int clientId, CreateSessionDto createSessionDto)
    {
        var session = _mapper.Map<Session>(createSessionDto);
        session.ClientId = clientId;
        session.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(session);
        await _repository.SaveChangesAsync();

        var sessionDto = _mapper.Map<SessionDto>(session);
        return CreatedAtAction(nameof(GetByClientId), new { clientId }, sessionDto);
    }
}
