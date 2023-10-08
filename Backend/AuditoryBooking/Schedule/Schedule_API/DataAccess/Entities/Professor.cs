using System.ComponentModel.DataAnnotations;

namespace Schedule_API.DataAccess.Entities;

public class Professor
{
    [Key]
    public Guid Id { get; set; }

    public string FullName { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}