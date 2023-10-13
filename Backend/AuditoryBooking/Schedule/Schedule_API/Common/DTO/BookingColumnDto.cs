namespace Schedule_API.Common.DTO;

public class BookingColumnDto
{
    public DateOnly Date { get; set; }
    public ICollection<BookingDto> bookings { get; set; }
}