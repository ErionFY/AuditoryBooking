using Microsoft.EntityFrameworkCore;
using Schedule_API.DataAccess.Entities;

namespace Schedule_API.DataAccess;

public class ScheduleDbContext:DbContext
{
    public DbSet<Audience> Audiences { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Subject> Subject { get; set; }
    

    public ScheduleDbContext(DbContextOptions options) : base(options)
    {
    }
}
