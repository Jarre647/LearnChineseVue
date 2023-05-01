using LearnChineseVue.Models;
using LearnChineseVue.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnChineseVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRMController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public CRMController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CheckUser")]
        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            return Ok("zalupa");
        }

        [HttpPost("get-users")]
        //[Authorize(Roles ="admin")]
        public async Task<CRMResponse> GetAllUsers()
        {
           return await _accountService.GetCRMDataAsync();
        }

        [HttpPost("update-users")]
        public async Task<UpdateUsersResponse> UpdateUsers([FromBody]UpdateUsersRequest request)
        {
            return new UpdateUsersResponse();
        }
    }
}
