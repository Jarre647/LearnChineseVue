using LearnChineseVue.Data;
using LearnChineseVue.Models;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LearnChineseVue.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;
        }

        public async Task<AccountViewModel> GetAccountByName(string accountName)
        {
            var getAcc = await _userManager.FindByEmailAsync( accountName );

            var response = new AccountViewModel
            {
                UserId = getAcc.Id
            };
            return response;
        }
    }
}
