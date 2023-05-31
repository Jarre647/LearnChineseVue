using LearnChineseVue.DbModels;
using LearnChineseVue.Models;
using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Repositories.Contracts
{
    public interface IChineseWordsRepository
    {
        Task<List<ChineseWordViewModel>> GetAllChineseWordsByUserAsync(string user);
        Task AddChineseWordInDictionaryAsync(ChineseWordDbModel model);
        Task<ChineseWordViewModel> GetChineseWordByIdAsync(int id, string userId);
        Task UpdateChineseWordAsync(UpdateChineseWordRequest request);
        Task<List<ChineseWordViewModel>> GetChineseWordsByGroupIdAsync(int groupId, string userId);
        Task<List<ChineseWordViewModel>> GetChineseWordsByGroupIdAnonymousAsync(int groupId);
    }
}
