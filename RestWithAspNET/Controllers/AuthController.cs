using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Business;
using RestWithAspNET.Data.VO;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid user data");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null) return Unauthorized();

            return Ok(token);
        }
        
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenData)
        {
            if (tokenData == null) return BadRequest("Invalid token data");

            var token = _loginBusiness.ValidateCredentials(tokenData);

            if (token == null) return Unauthorized();

            return Ok(token);
        }
    }
}