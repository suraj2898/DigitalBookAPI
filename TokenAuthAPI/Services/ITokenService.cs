using TokenAuthAPI.Models;

namespace TokenAuthAPI.Service
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, User user);
    }
}
