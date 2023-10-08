using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Profile;

public class ProfileDTO
{
    public string firstName{get;set;}
    public string secondName{get;set;}
    public string lastName{get;set;}
    [EmailAddress]
    public string Email {get;set;}
}
