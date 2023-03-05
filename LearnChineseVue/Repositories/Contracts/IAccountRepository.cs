using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<AccountViewModel> GetAccountByName(string accountName);
    }
}
