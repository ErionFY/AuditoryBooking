namespace Schedule_API.DataAccess.Entities;

public class Subject
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } //TODO: add Uniqueness
    public ICollection<Lesson> Lessons { get; set; }
}