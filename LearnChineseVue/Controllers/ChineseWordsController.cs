using LearnChineseVue.Models;
using LearnChineseVue.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnChineseVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ChineseWordsController : ControllerBase
    {
        private readonly IChineseWordApi _chineseWordApi;

        public ChineseWordsController(IChineseWordApi chineseWordApi)
        {
            _chineseWordApi = chineseWordApi;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("AddChineseWordInDictionary")]
        public async Task<ActionResult> AddChineseWordInDictionary([FromBody] SaveChineseWordRequestModel request)
        {
            var response = await _chineseWordApi.AddChineseWordInDictionaryAsync(request);
            return Ok();
        }

        [HttpPost("getAllWords")]
        public async Task<GetAllChineseWordsResponse>  GetAllChineseWords([FromBody] GetAllChineseWordsRequest request)
        {
            request.UserName = User.Identity.Name;
            var resp = await _chineseWordApi.GetAllChineseWordsByUserAsync(request);
            return resp;
        }

        [HttpPost("getWordById")]
        public async Task<GetChineseWordByIdResponse> GetChineseWordById([FromBody] GetChineseWordByIdRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _chineseWordApi.GetChineseWordByIdAsync(request);

            return response;
        }

        [HttpPost("UpdateChineseWord")]
        public async Task<UpdateChineseWordResponse> UpdateChinseWord([FromBody] UpdateChineseWordRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _chineseWordApi.UpdateChineseWordAsync(request);
            return response;
        }
    }
}
