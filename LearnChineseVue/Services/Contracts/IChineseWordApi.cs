using LearnChineseVue.Models;

namespace LearnChineseVue.Services.Contracts
{
    public interface IChineseWordApi
    {
        Task<SaveChineseWordResponseModel> SaveChineseWordAsync(SaveChineseWordRequestModel model);
        Task<GetAllChineseWordsResponse> GetAllChineseWordsByUserAsync(GetAllChineseWordsRequest request);
    }
}
