using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;

[ApiController]
[Route("api/professor")]
public class ProfessorController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ICollection<ProfessorDto>>> GetProfessors(Guid buildingId)
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
    public Task<IActionResult> CreateProfessor(ProfessorRequest request)
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
    public Task<IActionResult> UpdateProfessor(Guid professorId ,ProfessorRequest request)
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
    public Task<IActionResult> DeleteProfessor(Guid professorId)
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