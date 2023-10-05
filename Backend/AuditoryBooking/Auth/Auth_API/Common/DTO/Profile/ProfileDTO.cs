using System.ComponentModel.DataAnnotations;

namespace Auth_Common.DTO.Profile;

public class ProfileDTO
{
    public string Username{get;set;}
    [EmailAddress]
    public string Email {get;set;}
}
