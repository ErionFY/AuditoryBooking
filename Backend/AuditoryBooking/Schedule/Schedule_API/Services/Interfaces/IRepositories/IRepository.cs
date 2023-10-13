using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;

namespace Schedule_API.Services.Interfaces.IRepositories;

public interface IRepository
{
    Task AddProfessors(ICollection<ProfessorInTime>? professors);
    Task DeleteEntities();
    Task AddFaculties(ICollection<FacultyInTime>? faculties);
    Task AddGroups(ICollection<GroupDto>? groups);
    Task AddBuildings(ICollection<BuildingInTime> buildings);
    Task AddAudiences(IEnumerable<AudienceInTime> audiences);
    Task AddSchedule(ICollection<ScheduleColumnInTime> schedule);
}