using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;

[ApiController]
[Route("api/building/")]
public class BuildingController :ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<BuildingDto>>> GetBuildings()
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
    public Task<IActionResult> CreateBuilding(BuildingRequest request)
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
    public Task<IActionResult> UpdateBuilding(Guid buildingId, BuildingRequest request)
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
    public Task<IActionResult> DeleteBuilding(Guid buildingId)
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