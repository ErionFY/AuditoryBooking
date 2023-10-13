using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Schedule_API.Common.DTO;
using Schedule_API.Common.DTO_InTime;
using Schedule_API.DataAccess.Entities;
using Schedule_API.Services.Interfaces.IRepositories;
using Lesson = Schedule_API.DataAccess.Entities.Lesson;

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
                Building buildingDAL;
                if (audience.buildingId is not null)
                {
                    buildingDAL = await _scheduleDbContext.Buildings.FindAsync(new Guid(audience.buildingId));

                }
                else buildingDAL = null;

                string shortNameDAL;
                if (audience.shortName is null)
                    shortNameDAL = "";
                else
                {
                    shortNameDAL = audience.shortName;
                }

                if (audience.id is null)
                {
                    continue;
                }
                await _scheduleDbContext.Audiences.AddAsync(new Audience()
                {
                    Id = new Guid(audience.id),
                    Name = audience.name,
                    ShortName = shortNameDAL,
                    Building = buildingDAL
                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task AddSchedule(ICollection<ScheduleColumnInTime> schedule)
    {
        
        using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            foreach (var column in schedule)
            {
                
                foreach (var lesson in column.lessons)
                {
                // column.date - текущая дата

                if (lesson.type == "EMPTY")
                {
                    continue;
                }
                else
                {
                    // check if subject with such name exists
                    // if not -> add
                    // if subject exists -> skip
                    var subject = await _scheduleDbContext.Subjects.Where(s => s.Name.Equals(lesson.title)).FirstOrDefaultAsync();
                    if (subject == null)
                    {
                        await _scheduleDbContext.Subjects.AddAsync(new Subject
                        {
                            Name = lesson.title
                        });
                        await _scheduleDbContext.SaveChangesAsync();
                    }

                    bool result= Enum.TryParse(lesson.lessonType, out LessonType typeofLesson);
                    ICollection<Guid> groupsIds = lesson.groups.Select(g => new Guid(g.id)).ToList();


                    Professor professorDAL= await _scheduleDbContext.Professors.FindAsync(new Guid(lesson.professor.id));
                    if (professorDAL is null)
                    {
                        await AddProfessors( new List<ProfessorInTime>{lesson.professor} );
                        professorDAL= await _scheduleDbContext.Professors.FindAsync(new Guid(lesson.professor.id));
                    }
                    
                    Subject subjectDAL = await _scheduleDbContext.Subjects.Where(s => s.Name.Equals(lesson.title))
                        .FirstOrDefaultAsync();
                    ICollection<Group> groupsDAL= await _scheduleDbContext.Groups.Where(g => groupsIds.Contains(g.Id)).ToListAsync(); //достать все Id груп в Lesson.groups +> достать из БД все группы с таким ID
                    if (groupsIds is null)
                    {
                        Console.WriteLine("group is null");
                    }

                    Audience audienceDAL;
                    if (lesson.audience.id is not null)
                    {
                        audienceDAL= await _scheduleDbContext.Audiences.FindAsync(new Guid(lesson.audience.id));
                    }
                    else
                    {
                        audienceDAL = null;
                    }
                    
                    if (audienceDAL is null && lesson.audience.id is not null)
                    {
                        Console.WriteLine("audience is null");
                        await AddAudiences(new List<AudienceInTime> { lesson.audience });
                        audienceDAL= await _scheduleDbContext.Audiences.FindAsync(new Guid(lesson.audience.id));
                    }
                    
                    
                    await _scheduleDbContext.Lessons.AddAsync(new Lesson
                    {
                        Id = new Guid(lesson.id) ,
                        Type=typeofLesson ,// Конвертить lesson.type в enum
                        Date = column.date,
                        LessonNumber = lesson.lessonNumber,
                        Professor = professorDAL,
                        Subject = subjectDAL,
                        Groups = groupsDAL,
                        Audience = audienceDAL
                    });
                    
                    await _scheduleDbContext.SaveChangesAsync();
                    //find Professor
                    //find Auditory
                    //find Groups
                    //find Subject




                    //add lesson
                }
                


                    
                }
                
                
            }
        }
    }

    public async Task DeleteEntities()
    {    using (var scope = _serviceProvider.CreateScope())
        {
            var _scheduleDbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
            //Очистка базы данных
            await _scheduleDbContext.Lessons.ExecuteDeleteAsync();
            await _scheduleDbContext.Audiences.ExecuteDeleteAsync();
            await _scheduleDbContext.Buildings.ExecuteDeleteAsync();
            
            await _scheduleDbContext.Groups.ExecuteDeleteAsync();
            await _scheduleDbContext.Faculties.ExecuteDeleteAsync();
            
            await _scheduleDbContext.Professors.ExecuteDeleteAsync();
        }
    }
}