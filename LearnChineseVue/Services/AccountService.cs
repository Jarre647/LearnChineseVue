using LearnChineseVue.Models;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.Services.Contracts;

namespace LearnChineseVue.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CRMResponse> GetCRMDataAsync()
        {
            var response = new CRMResponse
            {
                Accounts = await _accountRepository.GetAllAccountsAsync(),
                Roles = await _accountRepository.GetAllRolesAsync()
            };

            foreach (var account in response.Accounts)
            {
                account.RoleName = response.Roles.FirstOrDefault(item => account.RoleId == item.RoleId)?.Name;
            }

            return response;
        }
        public async Task<UpdateUsersResponse> UpdateUsersAsync(UpdateUsersRequest request)
        {
            await _accountRepository.UpdateOrInsertUsersRoleAsync(request.Users);
            return new UpdateUsersResponse();
        }
    }
}
