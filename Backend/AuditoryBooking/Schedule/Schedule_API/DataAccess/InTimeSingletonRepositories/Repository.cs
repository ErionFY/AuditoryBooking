using Microsoft.EntityFrameworkCore;
using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;
using Schedule_API.DataAccess.Entities;
using Schedule_API.Services.Interfaces.IRepositories;

namespace Schedule_API.DataAccess.Repositories;


public class Repository:IRepository
{
  
    private readonly IServiceProvider _serviceProvider;
    public Repository(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task AddProfessors(ICollection<ProfessorInTime>? professors)
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


    public async Task AddFaculties(ICollection<FacultyInTime>? faculties)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var faculty in faculties)
            {
                await _scheduleDbContext.Faculties.AddAsync(new Faculty()
                {
                    Id=new Guid(faculty.id),
                    Name = faculty.name,
                    
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task AddGroups(ICollection<GroupDto>? groups)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var group in groups)
            {
                await _scheduleDbContext.Groups.AddAsync(new Group()
                {
                    Id = group.GroupId,
                    Name = group.Name,
                    IsSubgroup = group.IsSubgroup,
                    Faculty = await _scheduleDbContext.Faculties.FindAsync(group.FacultyId),
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task AddBuildings(ICollection<BuildingInTime> buildings)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var building in buildings)
            {
                await _scheduleDbContext.Buildings.AddAsync(new Building()
                {
                    Id = new Guid(building.id),
                    Name = building.name,
                    Address = building.address,
                    Longitude = building.longitude,
                    Latitude = building.latitude
                    
                    
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task AddAudiences(IEnumerable<AudienceInTime> audiences)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var audience in audiences)
            {
                await _scheduleDbContext.Audiences.AddAsync(new Audience()
                {
                    Id = new Guid(audience.id),
                    Name = audience.name,
                    ShortName = audience.shortName,
                    Building = await _scheduleDbContext.Buildings.FindAsync(new Guid(audience.buildingId)),
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task DeleteEntities()
    {    using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            //Очистка базы данных
            await _scheduleDbContext.Audiences.ExecuteDeleteAsync();
            await _scheduleDbContext.Buildings.ExecuteDeleteAsync();
            
            await _scheduleDbContext.Groups.ExecuteDeleteAsync();
            await _scheduleDbContext.Faculties.ExecuteDeleteAsync();
            
            await _scheduleDbContext.Professors.ExecuteDeleteAsync();
        }
    }
}