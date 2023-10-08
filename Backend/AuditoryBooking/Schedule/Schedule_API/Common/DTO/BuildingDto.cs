namespace Schedule_API.Common.DTO;

public class BuildingDto
{
    public BuildingDto( Guid buildingId,string name, string address, float? latitude, float? longitude )
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        BuildingId = buildingId;
    }
    public Guid BuildingId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    
        
}