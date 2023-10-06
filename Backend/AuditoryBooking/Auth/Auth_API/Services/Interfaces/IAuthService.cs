using Auth_Common.DTO.Auth;

namespace Auth_API;

public interface IAuthService
{
    Task SignUp(RegistrationRequest request);
    Task<Token>SignIn(LoginRequest request);
    //Task Logout();
    Task<Token> Refresh(string UserName);
}
