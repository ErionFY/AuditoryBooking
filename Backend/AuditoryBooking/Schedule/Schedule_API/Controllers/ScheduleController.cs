using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;
[ApiController]
[Route("api/schedule")]
public class ScheduleController:ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<Lesson>>> GetSchedule()//TODO: доделать endpoint'ы
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