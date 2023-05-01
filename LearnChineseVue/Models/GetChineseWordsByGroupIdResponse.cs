using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Models
{
    public class GetChineseWordsByGroupIdResponse
    {
        public List<ChineseWordViewModel> ChineseWords { get; set; } = new List<ChineseWordViewModel>();
    }
}
