using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings; 

        private readonly ILogger<AccountController> _logger;

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings, ILogger<AccountController> logger)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _logger = logger;
        }



        // Example Users
        // TODO: Change by real users in DB
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "martin@imaginagroup.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "pepe@imaginagroup.com",
                Name = "User1",
                Password = "pepe"
            }
        };


        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            
            try
            {

                var Token = new UserTokens();

                // TODO:
                // Search a user in context with LINQ
                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                 select user).FirstOrDefault();


                // TODO: Change to searchUser
                // var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (searchUser != null)
                {
                    // var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                        
                    }, _jwtSettings);

                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }catch (Exception ex)
            {

                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetToken)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetToken)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetToken)} - Critical Level Log");

                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {

            try
            {
                return Ok(Logins);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetUserList)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetUserList)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetUserList)} - Critical Level Log");

                return Problem(ex.ToString());
            }            
        }
    }
}
