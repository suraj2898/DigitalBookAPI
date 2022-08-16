using TokenAuthAPI.Models;
using TokenAuthAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuthAPI.Controllers
{
    [Route("Authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly DigitalBookContext _context;

        public readonly ITokenService _tokenService;

        private readonly IConfiguration _configuration;

        public readonly IAuthenticate _authenticate;
        public AuthenticationController(IConfiguration configuration, DigitalBookContext context, ITokenService tokenService, IAuthenticate authenticate)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context;
            _tokenService = tokenService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public ActionResult<string> Authenticate(User request)
        {            
            var user = _authenticate.ValidateUserCredentials(request.Username==null?"":request.Username, request.Password==null?"":request.Password);
            if (user.Username != null)
            {
                String token = _tokenService.BuildToken(_configuration["Authentication:SecretForKey"],
                    _configuration["Authentication:Issuer"],
                    new[]
                    {
                        _configuration["Authentication:Aud1"],
                        _configuration["Authentication:Aud2"],
                        _configuration["Authentication:Aud3"]
                    },
                    request.Username==null?"":request.Username, user
                    );
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
