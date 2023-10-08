namespace Schedule_API.DataAccess.Entities;

public class Lesson
{
    public Guid Id { get; set; }
    public int LessonNumber { get; set; }
    // mb new attributes
    
    public ICollection<Group> Groups { get; set; }
    public Subject Subject { get; set; }
    public Professor Professor { get; set; }
    public Audience Audience { get; set; }
}