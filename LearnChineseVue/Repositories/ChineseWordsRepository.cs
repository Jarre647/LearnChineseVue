using LearnChineseVue.Data;
using LearnChineseVue.DbModels;
using LearnChineseVue.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LearnChineseVue.Repositories
{
    public class ChineseWordsRepository : IChineseWordsRepository
    {
        private readonly ApplicationDbContext _context;

        public ChineseWordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChineseWordDbModel>> GetAllChineseWordsByUserAsync(string user)
        {
            return await _context.ChineseWords.Where(item => item.User == user).ToListAsync();
        }

        public async Task SaveChineseWordAsync(ChineseWordDbModel model)
        {
            _context.ChineseWords.Add(model); 
            await _context.SaveChangesAsync();
        }
    }
}
