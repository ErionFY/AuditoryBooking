using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Auth;

public class AccessTokenDTO
{
    [Required]
    public string AccessToken {get;set;}
    public DateTime AccessTokenExpiration {get;set;}
}
