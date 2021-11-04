using Chirpel2._0_Common.Interfaces.Auth;
using Chirpel2._0_Common.Interfaces.Context;
using System.Security.Claims;

namespace Chirpel2._0.Middlewares
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IChirpelContext dbContext, IJWTService jwtService)
        {
            string token = context.Request.Headers["X-JWT-Token"];
            try
            {
                if (jwtService.IsTokenValid(token))
                {
                    IEnumerable<Claim> claims = jwtService.GetTokenClaims(token);
                    string userId = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;

                    context.Items["User"] = dbContext.User.FirstOrDefault(x => x.Id.ToString() == userId);
                }
            }
            catch
            {
                //ignore catch
            }
            await _next(context);
        }

    }
}
