using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;
using Schedule_API.DataAccess.Entities;
using Schedule_API.Services.Interfaces;

namespace Schedule_API.Controllers;
[ApiController]
[Route("api/booking")]
public class BookingController:ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    
    public async Task<ICollection<BookingUnauthorizedUserColumnDto>> GetBookings(Guid audienceId,DateOnly dateFrom , DateOnly dateTo)
    {

        try
        {
           return await _bookingService.GetBookings(audienceId, dateFrom, dateTo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpGet("authorized")]
    [Authorize]//for user's bookings
    public Task<ActionResult<ICollection<BookingColumnDto>>> GetUserBookings(Guid audienceId,DateOnly dateFrom , DateOnly dateTo)
    {

        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("staff")]
    [Authorize]//Roles="Admin, Staff"
    public Task<ActionResult<ICollection<BookingColumnStaffDto>>> GetBookingsForStaff(Guid audienceId,DateOnly dateFrom , DateOnly dateTo)
    {
        //getBookings ForAudience
        
        //if default user -> return
        
        //if admins & staff =  show full info
        
        //show only approved
        
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    

    [HttpPut]
    [Authorize]
    public async Task UpdateBookingStatus(Guid bookingId,BookingStatus status)
    {
        
        //can change status of booking
        try
        {

          await  _bookingService.UpdateBookingStatus(bookingId, status);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    [HttpPost]
    [Authorize]
    public async Task CreateBookingOrder(string? groupNumber,BookingRequest request)
    {
        //
        // made by user -- userID
        // check if passed wrong group -> than forbides creation
        // auditory ->
        // Number of lesson + date
        // Comment + Role + groupNumber -> goes as private to admin/staff for approval
        
        try
        {
            var claims = HttpContext.User.Claims;
            var userId = claims.First().Value;
            await _bookingService.CreateBooking(new Guid(userId),groupNumber,request);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
}