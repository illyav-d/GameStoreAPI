using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly string _key;

        public AuthorizationController(IConfiguration configuration)
        {
            // Fetch the JWTSettings:Key from the configuration
            _key = configuration["JWTSettings:Key"];
            if (string.IsNullOrEmpty(_key))
            {
                throw new ArgumentNullException(nameof(_key), "JWT key was not found in the configuration.");
            }
        }
        private string CreateJWTToken(string[] roles)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            Byte[] keyBytes = Encoding.UTF8.GetBytes(_key);

            //Hier voegen we informatie over de gebruiker (claims) toe
            //Vanaf hier tot en met lijn 37 is te configureren
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, "Jos@magazijn.com"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, "Jos De Magazijnier"));

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            tokenDescriptor.Expires = DateTime.UtcNow.AddYears(10);
            tokenDescriptor.Audience = "http://localhost:5198/";
            tokenDescriptor.Issuer = "http://localhost:5198/";
            tokenDescriptor.SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256
                );

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        [HttpGet]
        public ActionResult Login(string[] roles)
        {
            return Ok(CreateJWTToken(roles));
        }
    }
}
