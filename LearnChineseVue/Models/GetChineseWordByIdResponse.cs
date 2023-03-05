using LearnChineseVue.ViewModels;

namespace LearnChineseVue.Models
{
    public class GetChineseWordByIdResponse
    {
        public ChineseWordViewModel ChineseWord { get; set; } = new ChineseWordViewModel();
    }
}
