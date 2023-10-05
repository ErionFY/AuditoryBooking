using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace Auth_DAL.Entities;



public class UserExtended:IdentityUser
{
    public string FirstName {get;set;}
    public string SecondName {get;set;}
    public string LastName {get;set;}

    //public Collection<RefreshToken> RefreshTokens {get;set;}
}
