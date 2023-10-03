using Auth_Common.DTO.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API;

[ApiController]
[Route("api/profile/")]
public class ProfileController:ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ProfileDTO>> GetProfile(){
        try{
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpGet("short")]
    [Authorize]
    public async Task<ActionResult<ShortProfileDTO>> GetShortProfile(){
        try{
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateProfile(){
        try{
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }
}
