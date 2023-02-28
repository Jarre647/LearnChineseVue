using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Models
{
    public class GetAllChineseWordsResponse
    {
        public List<ChineseWordViewModel> ChineseWords { get; set; } = new List<ChineseWordViewModel>();
    }
}
