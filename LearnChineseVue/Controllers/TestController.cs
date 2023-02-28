using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnChineseVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();               
            }
        }
    }
}
