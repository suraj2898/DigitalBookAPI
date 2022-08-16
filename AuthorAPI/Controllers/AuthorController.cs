using AuthorAPI.Models;
using AuthorAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthorAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        String _result=String.Empty;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] User user)
        {
            try
            {
                _result = _authorService.Login(user);
                if (_result == "OK")
                {
                    _result = "Valid User";
                    return Ok(_result);
                }
            }
            catch
            {
                _result = "Problem While Login";
            }
            return BadRequest(_result);
        }

        [HttpPost("Signup")]
        public ActionResult<string> Signup([FromBody] User user)
        {
            try
            {
                return Ok(_authorService.Signup(user));
            }
            catch
            {
                return BadRequest("Problem While Creating Account");
            }
        }

        [HttpPost("Book/Create")]
        public ActionResult<String> CreateBook([FromBody] Book book)
        {
            try
            {                
                return Ok(_authorService.CreateBook(book));
            }
            catch
            {
                return BadRequest("Problem While Creating Book");
            }
        }

        private AppAuthClaims GetAppAuthorizationClaim(ClaimsIdentity claimsIdentity)
        {
            return new AppAuthClaims
            {
                UserName = Convert.ToString(claimsIdentity.FindFirst("username").Value),
                UserType = Convert.ToString(claimsIdentity.FindFirst("usertype").Value)
            };
        }

        [HttpPut("Book/Block")]
        public ActionResult<string> BlockBook([FromBody] long bookid)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if(identity == null)
                {
                    return BadRequest("Problem While Blocking Book");
                }
                AppAuthClaims appAuthClaims = GetAppAuthorizationClaim(identity);
                if(appAuthClaims.UserType.ToUpper()!="A")
                {
                    return Unauthorized("You Don't Have Permission !! ");
                }
                _result = _authorService.BlockBook(bookid);
                if (_result == "OK")
                {
                    _result="Book Blocked Successfully";
                    return Ok(_result);
                }
            }
            catch
            {
                _result = "Problem While Blocking Book";
            }
            return BadRequest(_result);
        }

        [HttpPut("Book/Unblock")]
        public ActionResult<string> UnBlockBook([FromBody] long bookid)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    return BadRequest("Problem While UnBlocking Book");
                }
                AppAuthClaims appAuthClaims = GetAppAuthorizationClaim(identity);
                if (appAuthClaims.UserType.ToUpper() != "A")
                {
                    return Unauthorized("You Don't Have Permission !! ");
                }
                _result = _authorService.UnBlockBook(bookid);
                if (_result == "OK")
                {
                    _result="Book Unblocked Successfully";
                    return Ok(_result);
                }
            }
            catch
            {
                _result = "Problem while Unblocking Book";
            }
            return BadRequest(_result);
        }

        [HttpPut("Book/Update")]
        public ActionResult<string> UpdateBook([FromBody] Book book)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    return BadRequest("Problem While Updating Book");
                }
                AppAuthClaims appAuthClaims = GetAppAuthorizationClaim(identity);
                if (appAuthClaims.UserType.ToUpper() != "A")
                {
                    return Unauthorized("You Don't Have Permission !! ");
                }
                return Ok(_authorService.UpdateBook(book));
            }
            catch
            {
                return BadRequest("Problem While Updating Book");
            }
        }

    }
}
