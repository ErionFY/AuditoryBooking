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

    private readonly PeriodicTimer _timer = new(TimeSpan.FromHours(6)); //TODO:Вынести в конфиг время и поменять на большее

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
            
           await AddBuildingsAndAudiences();

            var groupsIds= await AddFacultiesAndGroups();

            foreach (var groupId in groupsIds)
            {
                var response =  await _inTimeApiParser.GetSchedule(groupId);
                //Получаем расписание и сразу добавляем
                if (response != null) await _repository.AddSchedule(response);
            }
            
            /* для каждой группы получить расписание за несколько месяцев назад ( 1 - 6 ) :
             Получить Id Каждой существующей группы
             Сделать соответствующий запрос
             Получить респонс - распарсить
             найти соответствующую Аудиторию и Преподователя,
             проверить, существует ли такой предмет в БД, если нет - добавить
             
             Привязать расписание к этим 4-ём сущностям - группа, преподователь, аудитория предмет
             
             */
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
    
    private async Task<ICollection<Guid>> AddFacultiesAndGroups()
    {
        var faculties =await _inTimeApiParser.GetFaculties();
        await _repository.AddFaculties(faculties);
        var facultiesIds = faculties.Select(f => f.id).ToList();
        ICollection<GroupDto>? groups = await _inTimeApiParser.GetGroups(facultiesIds);
        await _repository.AddGroups(groups);
        return groups.Select(g => g.GroupId).ToList();
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