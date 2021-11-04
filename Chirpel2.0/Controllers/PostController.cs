using Chirpel2._0.ViewModels;
using Chirpel2._0_Common.Attributes;
using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Common.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Chirpel2._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        public PostController(IChirpelContext chirpelContext)
        {

        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(new PostModel("je moeder"));
        }

        [HttpPost]
        [Authenticated]
        public IActionResult CreatePostModel(NewPost newPost)
        {
            return Ok();
        }
    }
}