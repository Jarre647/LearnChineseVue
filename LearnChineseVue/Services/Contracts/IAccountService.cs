using LearnChineseVue.Models;

namespace LearnChineseVue.Services.Contracts
{
    public interface IAccountService
    {
        Task<CRMResponse> GetCRMDataAsync();
        Task<UpdateUsersResponse> UpdateUsersAsync(UpdateUsersRequest request);
    }
}
