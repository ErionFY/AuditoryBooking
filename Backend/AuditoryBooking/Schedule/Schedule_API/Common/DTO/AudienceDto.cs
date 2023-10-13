namespace Schedule_API.Common.DTO;

public class AudienceDto
{

    public Guid AudienceId { get; set; }
    public Guid? BuildingId { get; set; }
    public string Name { get; set; }
    public string? ShortName { get; set; }
}