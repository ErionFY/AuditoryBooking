using Auth_Common.DTO.Profile;
using Auth_DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth_API;

public class ProfileService:IProfileService
{

        private readonly UserManager<UserExtended> _userManager;
   
        public ProfileService(UserManager<UserExtended> userManager) {
            _userManager = userManager;

        }



    public async Task<ProfileDTO> GetProfile(string userId){
        UserExtended user = await _userManager.FindByIdAsync(userId);

        return new ProfileDTO{
            Email=user.Email,
            firstName=user.FirstName,
            secondName=user.SecondName,
            lastName=user.LastName
        };
    }
    public async Task<ShortProfileDTO> GetShortProfile(string userId){

        UserExtended user = await _userManager.FindByIdAsync(userId);

        return new ShortProfileDTO{
            firstName=user.FirstName,
            secondName=user.SecondName,
            lastName=user.LastName
        };
    }
}
