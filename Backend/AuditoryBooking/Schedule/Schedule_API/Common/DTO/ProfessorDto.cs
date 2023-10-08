namespace Schedule_API.Common.DTO;

public class ProfessorDto
{
    public ProfessorDto(Guid professorId, string fullName, string? shortName)
    {
        ProfessorId = professorId;
        FullName = fullName;
        ShortName = shortName;
    }

    public Guid ProfessorId { get; set; }
    public string FullName { get; set; }
    public string? ShortName { get; set; }
}