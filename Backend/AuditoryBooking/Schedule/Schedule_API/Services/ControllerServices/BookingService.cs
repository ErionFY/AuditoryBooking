using Microsoft.EntityFrameworkCore;
using Schedule_API.Common.DTO;
using Schedule_API.DataAccess;
using Schedule_API.DataAccess.Entities;
using Schedule_API.Services.Interfaces;

namespace Schedule_API.Services.ControllerServices;

public class BookingService:IBookingService
{
    private readonly ScheduleDbContext _scheduleDbContext;

    public BookingService(ScheduleDbContext scheduleDbContext)
    {
        _scheduleDbContext = scheduleDbContext;
    }

    public async Task CreateBooking(Guid userId, string? groupNumber, BookingRequest request)
    {
        //Check if there is no lesson for this time., 
        //If there is -> then exception
        // if there is no lesson , then add booking request with status = NEW

        var checkLesson = await _scheduleDbContext.Lessons
            .Where(l => l.Date.Equals(request.Date) && l.LessonNumber.Equals(request.LessonNumber))
            .FirstOrDefaultAsync();
        if (checkLesson is null)
        {
            var audience = await _scheduleDbContext.Audiences.FindAsync(request.AudienceId);
            if (audience is not null)
            {
                await _scheduleDbContext.Bookings.AddAsync(new Booking
                {
                    UserId = userId,
                    Audience = audience,
                    Comment = request.CommentText,
                    Date = request.Date,
                    LessonNumber = request.LessonNumber,
                    Status = BookingStatus.NEW

                });
                await _scheduleDbContext.SaveChangesAsync();
            }
        }
        //как связать факультеты и их аудитории
        
    }

    public async Task UpdateBookingStatus(Guid bookingId, BookingStatus newStatus)
    {
        var booking =await _scheduleDbContext.Bookings.FindAsync(bookingId);
        if (booking is null)
        {
            throw new ArgumentNullException();
        }

        switch (booking.Status)
        {
            case BookingStatus.NEW:
                if ( newStatus.Equals(BookingStatus.APROVED)||newStatus.Equals(BookingStatus.REJECTED))
                {
                    booking.Status = newStatus;
                   
                    if (newStatus is BookingStatus.APROVED)
                    {
                        //can't be 2 or more bookings with status APPROVED
                        //new APPROVED overwrites 
                        //otherApproved - >canceled
                        
                        //get all of the bookings with the same time and date 
                        var bookings = await _scheduleDbContext.Bookings.Where(b =>
                            b.Date.Equals(booking.Date) && b.LessonNumber.Equals(booking.LessonNumber)).ToListAsync();
                        foreach (var bookingElement in bookings)
                        {
                            bookingElement.Status = BookingStatus.CANCELED;
                        }
                    }
                    await _scheduleDbContext.SaveChangesAsync();
                }
                break;
            case BookingStatus.APROVED:
                if (newStatus is BookingStatus.CANCELED)
                {
                    booking.Status = newStatus;
                    await _scheduleDbContext.SaveChangesAsync();
                }
                break;
            //RequiredApproval??
        }
        
        
        
        
    }

    public async Task<ICollection<BookingUnauthorizedUserColumnDto>> GetBookings(Guid audienceId, DateOnly dateFrom, DateOnly dateTo)
    {
        //get bookings where date>=dateFrom && date<=dateTo
        //foreach where date=BookingDate -> add
        //sortBy LessonNumber
        
        var bookings = await _scheduleDbContext.Bookings.Where(b =>
            b.Audience.Id.Equals(audienceId) && b.Date >= dateFrom && b.Date <= dateTo).ToListAsync();
        
        ICollection<BookingUnauthorizedUserColumnDto> bookingGrid=new List<BookingUnauthorizedUserColumnDto>();
        //
        for (var day = dateFrom; day <= dateTo; day = day.AddDays(1))
        {
            var column= new BookingUnauthorizedUserColumnDto();
            column.Date = day;
            
            List<Booking> bookingsCol = bookings.Where(b => b.Date.Equals(day)).OrderBy(b => b.LessonNumber).ToList();
            
            if (bookingsCol is not null)
            {
                ICollection<BookingShortDto> bookingColShortDto = new List<BookingShortDto>();
                foreach (var bookingItem in bookingsCol)
                {
                    var Audience = new AudienceDto
                    {
                        AudienceId = bookingItem.Audience.Id,
                        Name = bookingItem.Audience.Name,
                    };
                    BookingShortDto newBookingItem = new BookingShortDto
                    {
                        LessonNumber = bookingItem.LessonNumber,
                        UserId = bookingItem.UserId,
                        Audience = Audience,
                        BookingId = bookingItem.Id
                    };
                    bookingColShortDto.Add(newBookingItem);
                }

                column.bookings = bookingColShortDto;



            }
        }
        
        
        
        
        throw new NotImplementedException();
    }

    public Task<ICollection<BookingColumnDto>> GetAuthorizedUserBookings(Guid audienceId, Guid userId, DateOnly dateFrom, DateOnly dateTo)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookingColumnStaffDto>> GetBookingsForStaff(Guid audienceId, DateOnly dateFrom, DateOnly dateTo)
    {
        throw new NotImplementedException();
    }
}