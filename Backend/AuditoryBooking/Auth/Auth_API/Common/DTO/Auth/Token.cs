using System.ComponentModel.DataAnnotations;

namespace Auth_API;

public class Token
{
    [Required]
    public string TokenString {get;set;}
    //public DateTime TokenExpiration {get;set;}
    public TokenType tokenType {get;set;}
}
