using LearnChineseVue.Models;

namespace LearnChineseVue.Services.Contracts
{
    public interface IChineseWordApi
    {
        Task<SaveChineseWordResponseModel> AddChineseWordInDictionaryAsync(SaveChineseWordRequestModel model);
        Task<GetAllChineseWordsResponse> GetAllChineseWordsByUserAsync(GetAllChineseWordsRequest request);
        Task<GetChineseWordByIdResponse> GetChineseWordByIdAsync(GetChineseWordByIdRequest request);
    }
}
