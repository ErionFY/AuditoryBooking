namespace Schedule_API.Common.DTO;

public class AudienceRequest
{
    
    public Guid BuildingId { get; set; }
    public string Name { get; set; }
    public string? ShortName { get; set; }
}