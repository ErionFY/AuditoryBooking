using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;
using Schedule_API.Services.Interfaces;
using Schedule_API.Services.Interfaces.IRepositories;

namespace Schedule_API.Services;

public class InTimeApiParser:IInTimeApiParser
{
    private  readonly HttpClient _httpClient ;
    
    
    
    public InTimeApiParser(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async  Task<ICollection<ProfessorInTime>?> GetProfessors()
    {
        Console.WriteLine("GettingProfessors");

        var response = await _httpClient.GetFromJsonAsync<ICollection<ProfessorInTime>>("v1/professors");
        
        return response;
    }

    public async Task<ICollection<FacultyInTime>?> GetFaculties()
    {
        Console.WriteLine("GettingFaculties");
        var response = await _httpClient.GetFromJsonAsync<ICollection<FacultyInTime>>("v1/faculties");
        return response;
    }

    public async Task<IEnumerable<AudienceInTime>?> GetAudiences(List<string> buildingsIds)
    {
        IEnumerable<AudienceInTime>? audiences = new List<AudienceInTime>();
        foreach (var buildingId in buildingsIds)
        {
            var response =
                await _httpClient.GetFromJsonAsync<IEnumerable<AudienceInTime>>($"v1/buildings/{buildingId}/audiences");
            
            foreach (var audience in response)
            {
                audience.buildingId = buildingId;
            }
            
            if (audiences != null && audiences.Count()!=0) 
                audiences= audiences.Concat(response).ToList();
            else audiences = response;
        }

        return audiences;
    }

    public Task GetSchedule()
    {
        Console.WriteLine("GettingSchedule");
        throw new NotImplementedException();
    }

    public async Task<ICollection<GroupDto>?> GetGroups(List<string> facultiesIds)
    {
        ICollection<GroupDto>? groups = new List<GroupDto>();
        foreach (var facultyId in facultiesIds)
        {
            var response =
                await _httpClient.GetFromJsonAsync<ICollection<GroupInTime>>($"v1/faculties/{facultyId}/groups");
            foreach (var group  in response)
            {
                groups.Add(new GroupDto(new Guid(group.id),new Guid(facultyId),group.name,group.isSubgroup));
            }

            //Add facultyId for every group in response and convert to GroupDto
        }

        return groups;
    }

    public async Task<ICollection<BuildingInTime>?> GetBuildings()
    {
        var response = await _httpClient.GetFromJsonAsync<ICollection<BuildingInTime>>("v1/buildings");
        return response;
    }
}