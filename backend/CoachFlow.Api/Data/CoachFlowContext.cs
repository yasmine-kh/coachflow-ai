using Microsoft.EntityFrameworkCore;
using CoachFlow.Api.Models;

namespace CoachFlow.Api.Data;

public class CoachFlowContext : DbContext
{
    public CoachFlowContext(DbContextOptions<CoachFlowContext> options) : base(options) {}
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>()
            .HasOne(s => s.Client)
            .WithMany()
            .HasForeignKey(s => s.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
