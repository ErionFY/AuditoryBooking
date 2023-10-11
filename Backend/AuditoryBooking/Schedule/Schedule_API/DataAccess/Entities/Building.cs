namespace Schedule_API.DataAccess.Entities;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    
    public string? Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    
    
    private ICollection<Audience> Audiences { get; set; }
}