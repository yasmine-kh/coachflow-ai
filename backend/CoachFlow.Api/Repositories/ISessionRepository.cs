using CoachFlow.Api.Models;

namespace CoachFlow.Api.Repositories;

public interface ISessionRepository
{
    Task<List<Session>> GetByClientIdAsync(int clientId);
    Task<Session?> GetByIdAsync(int id);
    Task AddAsync(Session session);
    Task SaveChangesAsync();
}
