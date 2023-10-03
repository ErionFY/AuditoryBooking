using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Auth;

public class LoginRequest
{
    [EmailAddress]
    [Required]
    public string Email {get;set;}
    [Required]
    public string Password {get;set;}
}
