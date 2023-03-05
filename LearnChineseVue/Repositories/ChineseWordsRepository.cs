using LearnChineseVue.Data;
using LearnChineseVue.DbModels;
using LearnChineseVue.Exceptions;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.ViewModels;
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

        public async Task<List<ChineseWordViewModel>> GetAllChineseWordsByUserAsync(string user)
        {
            var chineseWordQuery = _context.ChineseWords;
            var orderNumChineseWordsQuery = _context.OrderNumChineseWordsByUser.Where(item => item.UserId == user);

            return await (from cw in chineseWordQuery
                          join ocw in orderNumChineseWordsQuery on cw.Id equals ocw.ChineseWordId into subocw
                          from ocw in subocw.DefaultIfEmpty()
                          select new ChineseWordViewModel
                          {
                              Id = cw.Id,
                              ChineseWord = cw.ChineseWord,
                              GroupId = ocw.GroupId != null ? ocw.GroupId : 0,
                              Pinyin = cw.Pinyin,
                              Tones = cw.Tones,
                              Translation = cw.Translation
                          }).ToListAsync();
        }

        public async Task AddChineseWordInDictionaryAsync(ChineseWordDbModel model)
        {
            if (_context.ChineseWords.Any(item => item.ChineseWord == model.ChineseWord))
            {
                throw new AlredyExistException("Это слово уже добавлено в словарь");
            }
            _context.ChineseWords.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<ChineseWordViewModel> GetChineseWordByIdAsync(int id, string userId)
        {
            try
            {
                var chineseWordQuery = _context.ChineseWords.Where(item => item.Id == id);
                var a = await chineseWordQuery.ToListAsync();
                var orderNumChineseWordsQuery = _context.OrderNumChineseWordsByUser.Where(item => item.UserId == userId);

                return await (from cw in chineseWordQuery
                              join ocw in orderNumChineseWordsQuery on cw.Id equals ocw.ChineseWordId into subocw
                              from ocw in subocw.DefaultIfEmpty()
                              select new ChineseWordViewModel
                              {
                                  Id = cw.Id,
                                  ChineseWord = cw.ChineseWord,
                                  GroupId = ocw.GroupId != null ? ocw.GroupId : 0,
                                  Pinyin = cw.Pinyin,
                                  Tones = cw.Tones,
                                  Translation = cw.Translation
                              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
