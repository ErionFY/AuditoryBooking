using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Auth_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Auth_API;

public class TokenService:ITokenService
{
    private readonly UserManager<UserExtended> _userManager;
    public TokenService(UserManager<UserExtended> userManager){
        _userManager=userManager;
    }

    public  async Task<Token> GenerateToken(TokenType tokenType , UserExtended user){

        ClaimsIdentity identity = await GetIdentityAsync(user, tokenType);
            int Lifetime = (tokenType == TokenType.Access) ? JwtConfigurations.AccessTokenLifetime : JwtConfigurations.RefreshTokenLifetime;
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                                           issuer: JwtConfigurations.Issuer,
                                           audience: JwtConfigurations.Audience,
                                           notBefore: now,
                                           claims: identity.Claims,
                                           expires: now.Add(new TimeSpan(0, Lifetime, 0)),
                                           signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //TODO adding refresh Tokens In database - > for login 

        return new Token{
            tokenType=tokenType,
            TokenString=encodedJwt
        };
    }


    public async Task<ClaimsIdentity> GetIdentityAsync(UserExtended user,TokenType type){
            var claims = new List<Claim>
            {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),//id
            new Claim("TokenType",(type==TokenType.Access)?"Access":"Refresh")
            };
            if (type == TokenType.Access)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    claims.Add(
                               new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                               );
                }
            }
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
    }


}
