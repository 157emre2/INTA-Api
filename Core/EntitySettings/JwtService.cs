using Core.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core;

public class JwtService : IJwtService
{
    public string GenerateToken(JwtTokenModel jwtTokenModel)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, jwtTokenModel.Username),
            new Claim(ClaimTypes.NameIdentifier, jwtTokenModel.UserId)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenModel.JwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtTokenModel.JwtIssuer,
            audience: jwtTokenModel.JwtAudience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
