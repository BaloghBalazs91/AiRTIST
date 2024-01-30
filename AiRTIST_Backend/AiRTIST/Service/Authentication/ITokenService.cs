using Microsoft.AspNetCore.Identity;

namespace AiRTIST.Service.Authentication
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, string? role);
    }
}
