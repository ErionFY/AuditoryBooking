using Auth_Common.DTO.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API;

[ApiController]
[Route("api/profile/")]
public class ProfileController:ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService){
        _profileService=profileService;
    }

    //ToDO create default role  , so only access token could be used on most calls
    [HttpGet]
    [Authorize] //Get user's profile
    public async Task<ActionResult<ProfileDTO>> GetProfile(){
        try{
            var claims = HttpContext.User.Claims;
            var userId = claims.First().Value;
            return  await _profileService.GetProfile(userId);
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpGet("short")] //get profile of specified user
    public async Task<ActionResult<ShortProfileDTO>> GetShortProfile(string userId){
        try{
            return  await _profileService.GetShortProfile(userId);
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
            // TODO update profile
        }
        catch(Exception e){
            throw;
        }
    }
}
