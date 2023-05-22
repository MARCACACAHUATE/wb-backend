using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using wb_backend.Models;

namespace wb_backend.Tools.Authorization;

public class JwtUtils : IJwtUtils {

    private readonly string _secretKey = Environment.GetEnvironmentVariable("SECRETKEY");

    public string GenerateJwtToken(User user){
        // generar token que dura 7 dias 
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int? ValidateJwtToken(string token){

        if(token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        try{
            tokenHandler.ValidateToken(token, new TokenValidationParameters{
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatiedToken);

            var jwtToken = (JwtSecurityToken)validatiedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            return userId;
        }catch{
            return null;
        }
    }

}