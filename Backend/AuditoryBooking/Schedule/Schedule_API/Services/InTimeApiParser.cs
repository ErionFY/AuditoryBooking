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

    public async Task GetFacultiesAndGroups()
    {
        Console.WriteLine("GettingFaculties");
        
        return ;
    }

    public Task GetBuildingsAndAudiences()
    {
        throw new NotImplementedException();
    }

    public Task GetSchedule()
    {
        Console.WriteLine("GettingSchedule");
        throw new NotImplementedException();
    }
}