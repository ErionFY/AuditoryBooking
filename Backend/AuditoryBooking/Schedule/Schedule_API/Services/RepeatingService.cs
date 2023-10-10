using Schedule_API.Services.Interfaces;
using Schedule_API.Services.Interfaces.IRepositories;

namespace Schedule_API.Services;

public class RepeatingService:BackgroundService
{
    private  readonly IInTimeApiParser _inTimeApiParser;
    private readonly IProfessorRepository _professorRepository;
    
    
    public RepeatingService(IInTimeApiParser inTimeApiParser, IProfessorRepository professorRepository)
    {
        _inTimeApiParser = inTimeApiParser;
        _professorRepository = professorRepository;
    }

    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(100)); //TODO:Вынести в конфиг время и поменять на большее

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
                //gettingAdding Professors
                var professors= await _inTimeApiParser.GetProfessors();
                //deleting all professors
                await _professorRepository.DeleteProfessors();
                // CreatingProfessors
                await _professorRepository.AddProfessor(professors);
                
                // Получить все факультеты и их группы
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        

        
        // Получить все факультеты и их группы
        // Получить все здания и их аудитории
        //Получить все расписание 

        //Распарсить всё и сложить в БД
    }

    
    
    
}