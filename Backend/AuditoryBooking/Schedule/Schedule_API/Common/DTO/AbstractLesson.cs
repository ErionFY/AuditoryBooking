namespace Schedule_API.Common.DTO;

public abstract class AbstractLesson
{
    //TODO: specify range of lesson Number
    public string? Type { get; set; }
    public int LessonNumber { get; set; }
    public TimeZoneInfo?  Starts { get; set; }
    public TimeZoneInfo?  Ends { get; set; }
    
}