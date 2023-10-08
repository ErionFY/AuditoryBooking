namespace Schedule_API.DataAccess.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsSubgroup { get; set; }

    public Faculty Faculty { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}