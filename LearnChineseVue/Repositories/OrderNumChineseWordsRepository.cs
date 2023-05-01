using LearnChineseVue.Data;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnChineseVue.Repositories
{
    public class OrderNumChineseWordsRepository : IOrderNumChineseWordsRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderNumChineseWordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetGroupIds(string userId)
        {
            return await _context.OrderNumChineseWordsByUser.Where(item=> item.UserId == userId).Select(a=> a.GroupId).Distinct().ToListAsync();
        }
    }
}
