namespace Schedule_API.Common.DTO;

public class BuildingRequest
{

    public string Name { get; set; }
    public string Address { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
}