using CoachFlow.Api.Data;
using CoachFlow.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachFlow.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly CoachFlowContext _context;

    public ClientRepository(CoachFlowContext context)
    {
        _context = context;
    }

    public Task<List<Client>> GetAllAsync() => _context.Clients.ToListAsync();

    public Task<Client?> GetByIdAsync(int id) => _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Client client) => await _context.Clients.AddAsync(client);

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
