using Auth_Common.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API;


[ApiController]
[Route("api/auth/")]
public class AuthController:ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService){
        _authService=authService;
    }


    [HttpPost("register")] 
    public  async Task<IActionResult> SignUp (RegistrationRequest request){
        try{
            await _authService.SignUp(request);
            return Ok();
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpPost("login")]//return refresh Token
    public async Task<ActionResult<Token>> SignIn(LoginRequest request){
        try{
            return await _authService.SignIn(request);
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout (bool AllAccounts){
        try{
            throw new NotImplementedException();
            //TODO Logout

        }
        catch(Exception e){
            throw;
        }
    }


    [HttpPost("refresh")]
    [Authorize]//should return AccessToken
    public async Task<ActionResult<Token>> Refresh(){
        try{

          return await  _authService.Refresh(User.Identity.Name);
        }
        catch(Exception e){
            throw;
        }
    }

}
