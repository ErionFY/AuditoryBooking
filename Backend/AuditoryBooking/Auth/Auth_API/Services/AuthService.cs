using Auth_Common.DTO.Auth;
using Auth_DAL;
using Auth_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Auth_API;

public class AuthService:IAuthService
{
   private readonly AuthDbContext _context;
   private readonly UserManager<UserExtended> _userManager;
   private readonly SignInManager<UserExtended> _signInManager;
    private readonly ITokenService _tokenService;
    

   public AuthService(AuthDbContext context,UserManager<UserExtended> userManager,SignInManager<UserExtended> signInManager,ITokenService tokenService ){
    _userManager=userManager;
    _signInManager=signInManager;
    _context=context;
    _tokenService=tokenService;
   }
   public async Task SignUp(RegistrationRequest request){
    
    UserExtended user =  new UserExtended{
        Email=request.Email,
        FirstName=request.firstName,
        SecondName=request.secondName,
        LastName=request.lastName,
        UserName = request.GetUserName()
    };
    var response = await _userManager.CreateAsync(user,request.Password);
    //check (response.Succeed)
     if(!response.Succeeded){
        foreach(IdentityError error in response.Errors)
            Console.WriteLine($"Error {error.Description} ({error.Code})");
        throw new InvalidDataException("Incorrect Registration Data");
     }
     
   }

   public async Task<Token> SignIn(LoginRequest request){
        //логин ->
        //сбор информации о пользователе
        // JWT token ->
        //RefreshTokenDTO

        UserExtended signedUser = await _userManager.FindByEmailAsync(request.Email);
        var result = await _signInManager.PasswordSignInAsync(signedUser.UserName,request.Password,true,false);

        

        if(result.Succeeded){
            //Generate RefreshToken
           return await _tokenService.GenerateToken(TokenType.Refresh,signedUser);
        }
        else{
            throw new InvalidDataException("Incorrect login Data");
        }

   }

    
    public async Task<Token> Refresh(string UserName){

        UserExtended user = await _userManager.FindByNameAsync(UserName);

        return await _tokenService.GenerateToken(TokenType.Access,user);

    }



}
