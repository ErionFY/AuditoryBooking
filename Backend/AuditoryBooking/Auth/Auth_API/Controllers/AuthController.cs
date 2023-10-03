using Auth_Common.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API;


[ApiController]
[Route("api/auth/")]
public class AuthController:ControllerBase
{
    [HttpPost("register")] //mb return TokenPair
    public  Task<IActionResult> SignUp(RegistrationRequest request){
        try{
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }

    [HttpPost("login")]
    public Task<ActionResult<TokenPairDTO>> SignIn(LoginRequest request){
        try{
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
        }
        catch(Exception e){
            throw;
        }
    }


    [HttpPost("refresh")]
    [Authorize]
    public Task<ActionResult<AccessTokenDTO>> Refresh(){
        try{
            throw new NotImplementedException();
        }
        catch(Exception e){
            throw;
        }
    }

}
