using Schedule_API.Common.DTO_InTime;

namespace Schedule_API.Services.Interfaces.IRepositories;

public interface IProfessorRepository
{
    Task AddProfessor(ICollection<ProfessorInTime>? professors);
    Task DeleteProfessors();
}