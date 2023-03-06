using LearnChineseVue.DbModels;
using LearnChineseVue.Exceptions;
using LearnChineseVue.Models;
using LearnChineseVue.Repositories.Contracts;
using LearnChineseVue.Services.Contracts;
using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Services
{
    public class ChineseWordApi : IChineseWordApi
    {
        private readonly IChineseWordsRepository _chineseWordsRepository;
        private readonly IAccountRepository _accountRepository;

        public ChineseWordApi(IChineseWordsRepository chineseWordsRepository,
                              IAccountRepository accountRepository)
        {
            _chineseWordsRepository = chineseWordsRepository;
            _accountRepository = accountRepository;
        }

        public async Task<SaveChineseWordResponseModel> AddChineseWordInDictionaryAsync(SaveChineseWordRequestModel request)
        {
            var response = new SaveChineseWordResponseModel();
            var model = new ChineseWordDbModel()
            {
                ChineseWord = request.ChineseWord,
                Pinyin = request.Pinyin,
                Tones = request.Tones,
                Translation = request.Translation
            };
            try
            {
                await _chineseWordsRepository.AddChineseWordInDictionaryAsync(model);
            }
            catch (AlredyExistException ex)
            {
                response.Errors = ex.Message;
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public async Task<GetAllChineseWordsResponse> GetAllChineseWordsByUserAsync(GetAllChineseWordsRequest request)
        {
            var getUser = await _accountRepository.GetAccountByName(request.UserName);
            var result = await _chineseWordsRepository.GetAllChineseWordsByUserAsync(getUser.UserId);
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

        public async Task<GetChineseWordByIdResponse> GetChineseWordByIdAsync(GetChineseWordByIdRequest request)
        {
            var getUser = await _accountRepository.GetAccountByName(request.UserName);
            var getWord = await _chineseWordsRepository.GetChineseWordByIdAsync(request.Id, getUser.UserId);
            var response = new GetChineseWordByIdResponse();
            response.ChineseWord.ChineseWord = getWord.ChineseWord;
            response.ChineseWord.Pinyin = getWord.Pinyin;
            response.ChineseWord.Translation = getWord.Translation;
            response.ChineseWord.GroupId = getWord.GroupId;
            response.ChineseWord.Id = getWord.Id;
            response.ChineseWord.Tones = getWord.Tones;
            return response;
        }
    }
}
