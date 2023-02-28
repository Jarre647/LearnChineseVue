using LearnChineseVue.DbModels;

namespace LearnChineseVue.Repositories.Contracts
{
    public interface IChineseWordsRepository
    {
        Task<List<ChineseWordDbModel>> GetAllChineseWordsByUserAsync(string user);
        Task SaveChineseWordAsync(ChineseWordDbModel model);
    }
}
