using Auth_Common.DTO.Profile;

namespace Auth_API;

public interface IProfileService
{
    Task<ProfileDTO> GetProfile(string userId);
    Task<ShortProfileDTO> GetShortProfile(string userId);
}
