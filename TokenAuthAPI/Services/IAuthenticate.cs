using TokenAuthAPI.Models;

namespace TokenAuthAPI.Service
{
    public interface IAuthenticate
    {
       User ValidateUserCredentials(string username, string password);
    }
}
