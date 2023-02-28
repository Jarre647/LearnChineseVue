using LearnChineseVue.DbModels;
using LearnChineseVue.Models;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.Services.Contracts;
using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Services
{
    public class ChineseWordApi : IChineseWordApi
    {
        private readonly IChineseWordsRepository _chineseWordsRepository;

        public ChineseWordApi(IChineseWordsRepository chineseWordsRepository)
        {
            _chineseWordsRepository = chineseWordsRepository;
        }

        public async Task<SaveChineseWordResponseModel> SaveChineseWordAsync(SaveChineseWordRequestModel request)
        {
            var response = new SaveChineseWordResponseModel();
            var model = new ChineseWordDbModel()
            {
                ChineseWord = request.ChineseWord,
                GroupId = request.GroupId,
                Pinyin = request.Pinyin,
                Tones = request.Tones,
                Translation = request.Translation,
                User = request.User,
            };
            await _chineseWordsRepository.SaveChineseWordAsync(model);
            return response;
        }

        public async Task<GetAllChineseWordsResponse> GetAllChineseWordsByUserAsync(GetAllChineseWordsRequest request)
        {
            var result = await _chineseWordsRepository.GetAllChineseWordsByUserAsync(request.UserName);
            var response = new GetAllChineseWordsResponse();
            foreach (var item in result)
            {
                var model = new ChineseWordViewModel
                {
                    ChineseWord = item.ChineseWord,
                    GroupId = item.GroupId,
                    Pinyin = item.Pinyin,
                    Tones = item.Tones,
                    Translation = item.Translation,
                    Id = item.Id 
                };
                response.ChineseWords.Add(model);
            }
            return response;
        }
    }
}
