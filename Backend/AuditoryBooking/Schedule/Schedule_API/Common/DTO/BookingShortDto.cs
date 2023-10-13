namespace Schedule_API.Common.DTO;

public class BookingShortDto
{
    public int LessonNumber { get; set; }
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public AudienceDto Audience { get; set; }
}