using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripBook.API.Configurations;

namespace TripBook.API.Services
{
    public class JwtService 
    {
        private readonly JwtConfiguration _jwtConfig;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtService(JwtConfiguration jwtConfig, JwtSecurityTokenHandler tokenHandler)
        {
            _jwtConfig = jwtConfig;
            _tokenHandler = tokenHandler;
        }

        public string Createtoken(string identifier, string email, string role)
        {
            DateTime now = DateTime.Now;
            JwtSecurityToken token = new(
                    _jwtConfig.Issuer,
                    _jwtConfig.Audience,
                    CreateClaims(identifier, email, role),
                    now,
                    now.AddSeconds(_jwtConfig.LifeTime),
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Signature)), SecurityAlgorithms.HmacSha256)

                );
            return _tokenHandler.WriteToken(token);
        }

        private IEnumerable<Claim> CreateClaims(string identifier, string email, string role)
        {
            yield return new Claim(ClaimTypes.NameIdentifier, identifier);
            yield return new Claim(ClaimTypes.Email, email);
            yield return new Claim(ClaimTypes.Role, role);
        }



    }
}
