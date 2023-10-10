using Microsoft.EntityFrameworkCore;
using Schedule_API.Common.DTO_InTime;
using Schedule_API.DataAccess.Entities;
using Schedule_API.Services.Interfaces.IRepositories;

namespace Schedule_API.DataAccess.Repositories;


public class ProfessorRepository:IProfessorRepository
{
  
    private readonly IServiceProvider _serviceProvider;
    public ProfessorRepository(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task AddProfessor(ICollection<ProfessorInTime>? professors)
    {

        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var professor in professors)
            {
                await _scheduleDbContext.Professors.AddAsync(new Professor
                {
                    Id = new Guid(professor.id),
                    FullName = professor.fullName
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }


    public async Task DeleteProfessors()
    {    using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
        await _scheduleDbContext.Professors.ExecuteDeleteAsync();
        }
    }
}