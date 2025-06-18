using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Vault
{
    internal static class GenerateAccessToken
    {
        public static string GenerateJwtToken(string username, string secretKey, string issuer, string audience, string role)
        {
            long expiresAtUnix = new DateTimeOffset(DateTime.UtcNow.Add(TimeSpan.FromMinutes(30))).ToUnixTimeSeconds();
            long notBeforeUnix = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            long issuedAtUnix = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            Claim[] claims =
            [
                new(JwtRegisteredClaimNames.Sub, username),
                new(JwtRegisteredClaimNames.Jti, Ulid.NewUlid().ToString()),
                new(JwtRegisteredClaimNames.Exp, expiresAtUnix.ToString()),
                new(JwtRegisteredClaimNames.Nbf, notBeforeUnix.ToString()),
                new(JwtRegisteredClaimNames.Iat, issuedAtUnix.ToString()),
                new(JwtRegisteredClaimNames.Iss, issuer),
                new(JwtRegisteredClaimNames.Aud, audience),
                new(ClaimTypes.Role, role)
            ];

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}