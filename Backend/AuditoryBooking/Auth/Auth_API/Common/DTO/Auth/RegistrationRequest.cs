using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Auth;

public class RegistrationRequest
{
    [Required]
    public string firstName {get;set;}
    [Required]
    public string secondName {get;set;}
    [Required]
    public string lastName {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [Required]
    public string Password {get;set;}
}
