using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Auth;

public class TokenPairDTO
{
    [Required]
    public string AccessToken {get;set;}
    public DateTime AccessTokenExpiration {get;set;}
    [Required]
    public string RefreshToken {get;set;}
    public DateTime RefreshTokenExpiration {get;set;}
}
