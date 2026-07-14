namespace CoachFlow.Api.DTOs;

public class SessionDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
