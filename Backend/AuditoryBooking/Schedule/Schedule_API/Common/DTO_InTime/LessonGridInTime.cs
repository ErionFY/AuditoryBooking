namespace Schedule_API.Common.DTO_InTime;

public class LessonGridInTime
{
    public string type { get; set; }
    public string id { get; set; }
    public int lessonNumber { get; set; }
    public int starts { get; set; }
    public int ends { get; set; }
    public string lessonType { get; set; }
    public ICollection<GroupInTime> groups { get; set; }
    public ICollection<ProfessorInTime> professors { get; set; }
}