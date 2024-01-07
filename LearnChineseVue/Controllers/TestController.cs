using LearnChineseVue.Models;
using LearnChineseVue.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearnChineseVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IChineseWordApi _chineseWordApi;
        public TestController(IChineseWordApi chineseWordApi)
        {
            _chineseWordApi = chineseWordApi;
        }

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

        [HttpGet("check")]
        public ActionResult Check() {
            return Ok("zalupa");
        }

        [HttpGet("getgetAllWords")]
        public async Task<ActionResult> GetGetAllChineseWords()
        {
            var request = new GetAllChineseWordsRequest
            {
                UserName = "ak647@mail.ru"
            };
            var resp = await _chineseWordApi.GetAllChineseWordsByUserAsync(request);
            return Ok(JsonSerializer.Serialize(resp));
        }
    }
}
