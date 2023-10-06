using Auth_DAL.Entities;

namespace Auth_API;

public interface ITokenService
{
Task<Token> GenerateToken(TokenType tokenType , UserExtended user);
}
