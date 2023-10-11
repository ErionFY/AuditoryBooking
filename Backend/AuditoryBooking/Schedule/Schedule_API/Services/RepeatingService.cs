using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;
using Schedule_API.Services.Interfaces;
using Schedule_API.Services.Interfaces.IRepositories;

namespace Schedule_API.Services;

public class RepeatingService:BackgroundService
{
    private  readonly IInTimeApiParser _inTimeApiParser;
    private readonly IRepository _repository;
    
    
    public RepeatingService(IInTimeApiParser inTimeApiParser, IRepository repository)
    {
        _inTimeApiParser = inTimeApiParser;
        _repository = repository;
    }

    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(30)); //TODO:Вынести в конфиг время и поменять на большее

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync();
        } 
    }

    private  async Task DoWorkAsync()
    {
        Console.WriteLine(DateTime.Now.ToString("O")); 
        //TODO:CallApi
        try
        {
            //Clean Database
            await _repository.DeleteEntities();

             await AddProfessors();

             await AddFacultiesAndGroups();

             await AddBuildingsAndAudiences();


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        

        
        
        //Получить все расписание 

        //Распарсить всё и сложить в БД
    }

    private async Task AddProfessors()
    {
        //gettingAdding Professors
        var professors= await _inTimeApiParser.GetProfessors();
        //deleting all professors
        // CreatingProfessors
        await _repository.AddProfessors(professors);

    }
    
    private async Task AddFacultiesAndGroups()
    {
        var faculties =await _inTimeApiParser.GetFaculties();
        await _repository.AddFaculties(faculties);
        var facultiesIds = faculties.Select(f => f.id).ToList();
        ICollection<GroupDto>? groups = await _inTimeApiParser.GetGroups(facultiesIds);
        await _repository.AddGroups(groups);

    }

    private async Task AddBuildingsAndAudiences()
    {
        var buildings =await _inTimeApiParser.GetBuildings();
        await _repository.AddBuildings(buildings);
        var buildingsIds = buildings.Select(b => b.id).ToList();
        var audiences = await _inTimeApiParser.GetAudiences(buildingsIds);
        await _repository.AddAudiences(audiences);
    }
    
    
    
}