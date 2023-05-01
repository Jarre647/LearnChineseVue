namespace LearnChineseVue.Repositories.Contracts
{
    public interface IOrderNumChineseWordsRepository
    {
        Task<List<int>> GetGroupIds(string userId);
    }
}
