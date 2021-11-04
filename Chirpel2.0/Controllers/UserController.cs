using Chirpel2._0.ViewModels;
using Chirpel2._0_Common.Attributes;
using Chirpel2._0_Common.Interfaces.Auth;
using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Common.Models.DataModels;
using Chirpel2._0_Data;
using Chirpel2._0_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chirpel2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserLogic _userLogic;
        public UserController(IChirpelContext chirpelContext, IJWTService jwtService)
        {
            _userLogic = new UserLogic(new UserData(chirpelContext), jwtService);
        }

        [HttpPost]
        public IActionResult Register(NewUser newUser)
        {
            return Ok(_userLogic.Register(newUser.Name, newUser.Email, newUser.Password));
        }
        
        [Authenticated]
        [HttpGet("verify")]
        public IActionResult Verify()
        {
            return Ok((UserModel)HttpContext.Items["User"]);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_userLogic.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userLogic.GetAll());
        }


    }
}
