using Microsoft.AspNetCore.Identity;

namespace NZWalkes.API.Repositers
{
    public interface ITokenRepositery
    {
        string CreatedJWTToken(IdentityUser user, List<string> roles);
    }
}
