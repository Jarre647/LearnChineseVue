using LearnChineseVue.Models;

namespace LearnChineseVue.Services.Contracts
{
    public interface IAccountService
    {
        Task<CRMResponse> GetCRMDataAsync();
    }
}
