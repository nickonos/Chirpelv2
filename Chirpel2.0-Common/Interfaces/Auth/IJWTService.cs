using System.Security.Claims;

namespace Chirpel2._0_Common.Interfaces.Auth
{
    public interface IJWTService
    {
        bool IsTokenValid(string token);
        string GenerateToken(IJWTContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
