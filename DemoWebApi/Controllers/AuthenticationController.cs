using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WebApi.BusinessLogic.AuthServices;
using WebApi.Domain.AuthModels;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationServices _authenticationServices;
        private IMapper _mapper;
        private ITokenHandler _tokenHandler;
        public AuthenticationController(IAuthenticationServices authenticationServices,IMapper mapper, ITokenHandler tokenHandler)
        {
            _authenticationServices = authenticationServices;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDetailsDTO registerDetails)
        {
            var user = await _authenticationServices.IsUserAlreadyExists(_mapper.Map<RegisterDetails>(registerDetails));
            if(user != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"User Already Exists");//, new Response { Status = "Error", Message = "User Already Exists" });
            }
             var loginDetails = _mapper.Map<RegisterDetails>(registerDetails);
            _authenticationServices.AddUser(loginDetails);
            return Ok(_mapper.Map<RegisterDetailsDTO>(loginDetails));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginInfo)
        {
            var user = await _authenticationServices.AuthenticateUser(_mapper.Map<LoginInfo>(loginInfo));
            if(user == null)
            {
                return BadRequest("User Not Found");
            }
            var registeredUser = await _authenticationServices.IsUserAlreadyExists(user);
            string token = _tokenHandler.CreateToken(_mapper.Map<RegisterDetailsDTO>(registeredUser));
            return Ok(token);
        }
    }
}
