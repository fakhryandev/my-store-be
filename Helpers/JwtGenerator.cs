using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class JwtGenerator
{

    public static string GenerateJwtToken()
    {

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ogOe0tGQm1ahy5WdE2aYX6Xv56rwMvEj"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: "fakhryan",
            audience: "fakhryan",
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}