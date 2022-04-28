using AutoMapper;
using JWT.TokenV2.DTO;
using JWT.TokenV2.Model;
using JWT.TokenV2.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.TokenV2.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserDto model)
        {
            var user = _userRepository.Authenticate(model.UserName, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "UserName or Password is Incorrect" });
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegisterDto model)
        {
            bool ifuserNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!ifuserNameUnique)
            {
                return BadRequest(new { message = "UserName Already Exists" });
            }
            var user = _userRepository.Register(model.UserName, model.Password,model.Role);
            if(user == null)
            {
                return BadRequest(new { message = "Error While Register" });
            }

            var userData = _mapper.Map<User>(user);

            return Ok(userData);
        }
    }
}
