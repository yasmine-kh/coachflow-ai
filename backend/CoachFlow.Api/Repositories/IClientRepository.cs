using CoachFlow.Api.Models;

namespace CoachFlow.Api.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task AddAsync(Client client);
    Task SaveChangesAsync();
}
