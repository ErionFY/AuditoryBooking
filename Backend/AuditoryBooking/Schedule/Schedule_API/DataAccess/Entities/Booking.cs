
using System.ComponentModel.DataAnnotations;

namespace Schedule_API.DataAccess.Entities;

public class Booking
{
    
    //IdentifyingNumber- Бронь номер 12345
    
    //User's group
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
    public int LessonNumber { get; set; }
    public string? Comment { get; set; }
    
    public BookingStatus Status { get; set; }
    
    public Audience Audience { get; set; }
}