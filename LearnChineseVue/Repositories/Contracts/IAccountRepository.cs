using LearnChineseVue.Models.InsertModels;
using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<AccountViewModel> GetAccountByName(string accountName);
        Task<List<AccountsViewModel>> GetAllAccountsAsync();
        Task<List<RoleViewModel>> GetAllRolesAsync();
        Task UpdateOrInsertUsersRoleAsync(List<UpdateUserInsertModel> model);
    }
}
