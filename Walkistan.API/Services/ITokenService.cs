using Microsoft.AspNetCore.Identity;

namespace Walkistan.API.Services
{
    public interface ITokenService
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
