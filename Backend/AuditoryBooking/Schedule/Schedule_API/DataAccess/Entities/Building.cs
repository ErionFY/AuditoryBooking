namespace Schedule_API.DataAccess.Entities;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    //Longitude
    //Latitude
    private ICollection<Audience> Audiences { get; set; }
}