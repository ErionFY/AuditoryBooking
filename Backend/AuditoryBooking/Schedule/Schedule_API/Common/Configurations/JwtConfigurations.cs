using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Schedule_API.Common.Configurations;

public class JwtConfigurations
{
    public const string Issuer = "JwtTestIssuer"; // издатель токена
    public const string Audience = "JwtTestClient"; // потребитель токена
    private const string Key = "this is my custom Secret key for authentication";   // ключ для шифрации
    public static  int AccessTokenLifetime = 10000; // время жизни токена - 100 минут
    public static int RefreshTokenLifetime = 60000;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}