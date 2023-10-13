namespace Schedule_API.Common.DTO;

public class BookingRequest
{
    public string? CommentText { get; set; }
    public Guid AudienceId { get; set; }
    public DateOnly Date { get; set; }
    public int LessonNumber { get; set; }
}