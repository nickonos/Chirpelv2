using Chirpel2._0_Common.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Chirpel2._0_Common.Models
{
    public class JWTContainerModel : IJWTContainerModel
    {
        public string SecurityAlogrithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 10080;
        public Claim[] Claims { get; set; }
    }
}
