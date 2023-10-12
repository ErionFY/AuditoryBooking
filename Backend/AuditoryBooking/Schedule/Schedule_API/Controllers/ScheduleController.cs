using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;
[ApiController]
[Route("api/schedule")]
public class ScheduleController:ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<ScheduleColumnDto>>> GetSchedule(ScheduleType type,Guid id,DateOnly dateFrom , DateOnly dateTo)//TODO: доделать endpoint'ы
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
}