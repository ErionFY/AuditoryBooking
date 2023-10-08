using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;

[ApiController]
[Route("api/faculty")]
public class FacultyController:ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<FacultyDto>>> GetFaculties()
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
    public Task<IActionResult> CreateFaculty(FacultyRequest request)
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
    public Task<IActionResult> UpdateFaculty(Guid facultyId,FacultyRequest request)
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
    public Task<IActionResult> DeleteFaculty(Guid facultyId)
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