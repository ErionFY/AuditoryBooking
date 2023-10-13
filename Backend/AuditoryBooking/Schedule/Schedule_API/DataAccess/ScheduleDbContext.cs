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
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    

    public ScheduleDbContext(DbContextOptions options) : base(options)
    {
    }
}
