using TokenAuthAPI.Models;

namespace TokenAuthAPI.Service
{
    public class Authenticate:IAuthenticate
    {
        public readonly DigitalBookContext _context;

        public Authenticate(DigitalBookContext context)
        {
            _context = context;
        }

        public User ValidateUserCredentials(string username,string password)
        {
            var userdata = _context.Users.Where(s => s.Username == username && s.Password==password);  
            if(userdata.Count()==0)
            {
                return new User();
            }
            return userdata.First();
        }

    }
}
