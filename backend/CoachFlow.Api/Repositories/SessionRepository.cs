using CoachFlow.Api.Data;
using CoachFlow.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachFlow.Api.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly CoachFlowContext _context;

    public SessionRepository(CoachFlowContext context)
    {
        _context = context;
    }

    public Task<List<Session>> GetByClientIdAsync(int clientId) =>
        _context.Sessions
            .Where(s => s.ClientId == clientId)
            .OrderByDescending(s => s.Date)
            .ToListAsync();

    public Task<Session?> GetByIdAsync(int id) => _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddAsync(Session session) => await _context.Sessions.AddAsync(session);

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
