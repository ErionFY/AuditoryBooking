using System.ComponentModel.DataAnnotations;

namespace Schedule_API.DataAccess.Entities;

public class Faculty
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    
    private ICollection<Group> Groups { get; set; }
}