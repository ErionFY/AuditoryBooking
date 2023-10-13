namespace Schedule_API.Common.DTO;

public class BookingUnauthorizedUserColumnDto
{
    public DateOnly Date { get; set; }
    public ICollection<BookingShortDto> bookings { get; set; }
}