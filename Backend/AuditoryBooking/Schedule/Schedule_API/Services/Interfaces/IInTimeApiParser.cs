using Schedule_API.Common.DTO_InTime;

namespace Schedule_API.Services.Interfaces;

public interface IInTimeApiParser
{

      Task<ICollection<ProfessorInTime>?> GetProfessors();
      Task GetFacultiesAndGroups();
      Task GetBuildingsAndAudiences();
      Task GetSchedule();
}