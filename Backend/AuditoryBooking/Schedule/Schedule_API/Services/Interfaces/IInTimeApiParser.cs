using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;

namespace Schedule_API.Services.Interfaces;

public interface IInTimeApiParser
{

      Task<ICollection<ProfessorInTime>?> GetProfessors();
      Task<ICollection<FacultyInTime>?> GetFaculties();
      Task<IEnumerable<AudienceInTime>?> GetAudiences(List<string> buildingsIds);
      Task GetSchedule();
      Task<ICollection<GroupDto>?> GetGroups(List<string> facultiesIds);
      Task<ICollection<BuildingInTime>?> GetBuildings();
}