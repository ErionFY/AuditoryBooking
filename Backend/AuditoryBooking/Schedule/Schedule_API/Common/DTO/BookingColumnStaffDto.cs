namespace Schedule_API.Common.DTO;

public class BookingColumnStaffDto
{
    public DateOnly Date { get; set; }
    public ICollection<BookingDto> bookings { get; set; }
}