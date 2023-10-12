namespace Schedule_API.Common.DTO;

public class ScheduleColumnDto
{
    public DateOnly Date { get; set; }
    public ICollection<Lesson> lessons { get; set; } //TODO: понять, как возвращать либо Lesson , дибо Empty Lesson
    
}