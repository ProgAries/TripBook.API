using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripBook.API.Services;
using TripBook.BLL.DTO.Users;
using TripBook.BLL.Services;

namespace TripBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly JwtService _jwtService;
        private readonly LoginService _service;

        public AuthController(JwtService jwtService, LoginService service)
        {
            _jwtService = jwtService;
            _service = service;
        }


        [HttpPost]
        public IActionResult Login(UserLoginDTO dto)
        {

            try
            {
                UserDTO user = _service.Login(dto);
                string token = _jwtService.Createtoken(user.Id.ToString(), user.Email, "user");
                return Ok(new { token });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        

    }
}
