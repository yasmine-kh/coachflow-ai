namespace CoachFlow.Api.DTOs;

public class CreateSessionDto
{
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; } = string.Empty;
}
