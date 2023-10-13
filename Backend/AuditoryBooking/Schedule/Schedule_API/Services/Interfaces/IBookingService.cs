using Schedule_API.Common.DTO;
using Schedule_API.DataAccess.Entities;

namespace Schedule_API.Services.Interfaces;

public interface IBookingService
{
    Task CreateBooking(Guid userId, string? groupNumber, BookingRequest request);
    Task UpdateBookingStatus(Guid bookingId, BookingStatus newStatus);

    Task<ICollection<BookingUnauthorizedUserColumnDto>> GetBookings(Guid audienceId,DateOnly dateFrom , DateOnly dateTo);
    Task<ICollection<BookingColumnDto>> GetAuthorizedUserBookings(Guid audienceId,Guid userId,DateOnly dateFrom , DateOnly dateTo);
    Task<ICollection<BookingColumnStaffDto>> GetBookingsForStaff(Guid audienceId,DateOnly dateFrom , DateOnly dateTo);
}