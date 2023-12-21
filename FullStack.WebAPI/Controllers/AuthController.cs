using FullStack.WebAPI.Defaults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullStack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("Token")]
        public async Task<IActionResult> Token()
        {

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenInfoDefaults.Key)), SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "Admin")
        };


            var securityJwtToken = new JwtSecurityToken(issuer: TokenInfoDefaults.Issuer, audience: TokenInfoDefaults.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(TokenInfoDefaults.Minute), signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityJwtToken);

            return Created("", new
            {
                token = token,
            });
        }
    }
}
