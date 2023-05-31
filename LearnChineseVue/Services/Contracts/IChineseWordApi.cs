using LearnChineseVue.Models;

namespace LearnChineseVue.Services.Contracts
{
    public interface IChineseWordApi
    {
        Task<SaveChineseWordResponseModel> AddChineseWordInDictionaryAsync(SaveChineseWordRequestModel model);
        Task<GetAllChineseWordsResponse> GetAllChineseWordsByUserAsync(GetAllChineseWordsRequest request);
        Task<GetChineseWordByIdResponse> GetChineseWordByIdAsync(GetChineseWordByIdRequest request);
        Task<UpdateChineseWordResponse> UpdateChineseWordAsync(UpdateChineseWordRequest request);
        Task<GetGroupsResponse> GetGroupsAsync(GetGroupsRequest request);
        Task<GetGroupsResponse> GetAnonymousGroup(GetGroupsRequest request);
        Task<GetChineseWordsByGroupIdResponse> GetChineseWordsByGroupIdAsync(GetChineseWordsByGroupIdRequest request);
        Task<GetChineseWordsByGroupIdResponse> GetChineseWordsByGroupIdAnonymousAsync(GetChineseWordsByGroupIdRequest request);
    }
}
