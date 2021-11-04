using System.Security.Claims;

namespace Chirpel2._0_Common.Interfaces.Auth
{
    public interface IJWTContainerModel
    {
        string SecurityAlogrithm { get; set; } 
        int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}
