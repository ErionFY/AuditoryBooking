namespace Schedule_API.Common.DTO_InTime;

public class ScheduleColumnInTime
{
    public DateOnly date { get; set; }
    public ICollection<LessonGridInTime> lessons { get; set; } 
}