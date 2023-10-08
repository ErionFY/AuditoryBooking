using Microsoft.AspNetCore.Mvc;
using Schedule_API.Common.DTO;

namespace Schedule_API.Controllers;

[ApiController]
[Route("api/group")]
public class GroupController:ControllerBase
{
   [HttpGet]
   public Task<ActionResult<ICollection<FacultyDto>>> GetFacultyGroups(Guid facultyId)
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
   public Task<IActionResult> CreateGroup(GroupRequest request)
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
   public Task<IActionResult> UpdateGroup(Guid groupId,GroupRequest request)
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
   public Task<IActionResult> DeleteGroup(Guid groupId)
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