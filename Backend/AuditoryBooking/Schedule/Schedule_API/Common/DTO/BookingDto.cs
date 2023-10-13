using Schedule_API.DataAccess.Entities;

namespace Schedule_API.Common.DTO;

public class BookingDto
{
    public BookingStatus Status { get; set; }
    public string Comment { get; set; }
    public int LessonNumber { get; set; }
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public AudienceDto Audience { get; set; }
}