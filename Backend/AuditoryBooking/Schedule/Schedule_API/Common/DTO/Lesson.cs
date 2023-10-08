using System.ComponentModel.DataAnnotations;

namespace Schedule_API.Common.DTO;

public  class Lesson:AbstractLesson
{   
    
    public Guid LessonId { get; set; }
    public string SubjectName { get; set; }// - какой предмет 
    public string Title { get; set; }
    public LessonType LessonType { get; set; }
    public ICollection<GroupDto> Groups { get; set; }
    public ProfessorDto Professor { get; set; }
    public AudienceDto Audience { get; set; }
}