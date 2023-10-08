namespace Schedule_API.Common.DTO;

public class AudienceDto
{
    public AudienceDto(Guid audienceId, Guid buildingId, string name, string? shortName)
    {
        AudienceId = audienceId;
        BuildingId = buildingId;
        Name = name;
        ShortName = shortName;
    }

    public Guid AudienceId { get; set; }
    public Guid? BuildingId { get; set; }
    public string Name { get; set; }
    public string? ShortName { get; set; }
}