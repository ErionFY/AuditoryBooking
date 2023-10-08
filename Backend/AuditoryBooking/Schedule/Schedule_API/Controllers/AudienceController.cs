using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;

[ApiController]
[Route("api/audience")]
public class AudienceController:ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<AudienceDto>>> GetBuildingAudiences(Guid buildingId)
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

    [HttpPost]
    public Task<IActionResult> CreateAudience(AudienceRequest request)
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
    
    [HttpPut]
    public Task<IActionResult> UpdateAudience(Guid audienceId,AudienceRequest request)
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
    
    [HttpDelete]
    public Task<IActionResult> DeleteAudience(Guid audienceId)
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