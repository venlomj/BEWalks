using Microsoft.AspNetCore.Identity;

namespace BEWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
